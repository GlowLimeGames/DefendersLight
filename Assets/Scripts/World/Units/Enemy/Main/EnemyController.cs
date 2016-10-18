/*
 * Author(s): Isaiah Mann
 * Description: Controls the enemies in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyController : UnitController<IEnemy, Enemy, EnemyList>, IEnemyController {
	EventActionInt waveAdvance;

	public const string ENEMY_TAG = "Enemy";
	const string UNDEAD_KEY = "Undead";
	const string BRUTE_KEY = "Brute";
	const string SHADE_KEY = "Shade";
	public GameObject[] EnemyPrefabs;
	Dictionary<string, GameObject> orderedEnemyPrefabs = new Dictionary<string, GameObject>();
	public static EnemyController Instance;
	int enemiesAlive = 0;
	int currentWaveIndex = 1;
	Season currentSeason;
	EnemyWave currentWave = null;
	MathEquation spawnCountEquation = LinearEquation.Default;
    HashSet<EnemyBehaviour> activeEnemies = new HashSet<EnemyBehaviour>();
	public int ICurrentWaveIndex {
		get {
			return currentWaveIndex;
		}
	}

	public virtual void Setup (WorldController worldController, DataController dataController, MapController mapController, string unitTemplateJSONPath, MathEquation spawnCountEquation) {
		base.Setup(worldController, dataController, mapController, unitTemplateJSONPath);
		this.spawnCountEquation = spawnCountEquation;
		int quadrantAsIndex = 0;
		foreach (EnemySpawnPoint spawnPoint in EnemySpawnPoint.SpawnPoints.Values) {
			spawnPoint.Setup((MapQuadrant) quadrantAsIndex);
			spawnPoint.ChooseStartingTile();
			spawnPoint.SetPath(createEnemyPath(spawnPoint.Tile));
			quadrantAsIndex++;
			quadrantAsIndex %= 4;
		}
	}

	public void SpawnWave () {
		SpawnWave(currentWaveIndex);
	}

	public void SpawnWave (int waveIndex) {
		StatsPanelController.Instance.SetWave(waveIndex);
		callOnWaveAdvance(waveIndex);
		// TODO: Implement non-placeholder functionality
		StartCoroutine(RunSpawnWave(waveIndex, 0.5f));
	}

	public void SetSeason (Season season) {
		this.currentSeason = season;
	}

	public void SubscribeToWaveAdvance (EventActionInt onWaveAdvance) {
		waveAdvance += onWaveAdvance;
	}

	public void UnusubscribeFromWaveAdvance (EventActionInt onWaveAdvance) {
		waveAdvance -= onWaveAdvance;
	}

	void callOnWaveAdvance (int waveIndex) {
		if (waveAdvance != null) {
			waveAdvance(waveIndex);
		}
	}

	IEnumerator RunSpawnWave (int waveIndex, float spawnDelay) {
		int enemiesInWaveCount = GetEnemyCount(waveIndex);
		string[] enemyTypes = GetEnemyTypes(waveIndex);
		enemiesAlive += enemiesInWaveCount;
		for (int i = 0; i < enemiesInWaveCount; i++) {
			SpawnEnemy((Direction)(i%4), enemyTypes[i]);
			yield return new WaitForSeconds(spawnDelay);
		}
		updateEnemiesAliveText();
	}

	void updateEnemiesAliveText () {
		StatsPanelController.Instance.SetEnemies(enemiesAlive);
	}

	int GetEnemyCount (int waveIndex) {
		// TODO: Implement actual difficulty curve
		return spawnCountEquation.Calculate(waveIndex);
	}

    public void setWave(int waveIndex) {
        currentWaveIndex = waveIndex;
        KillAllEnemies();
        SpawnWave();
    }

	string[] GetEnemyTypes (int waveIndex) {
		// TODO: Implement actual enemy type spawning formula
		string [] enemyKeys = ArrayUtil.Fill(new string[GetEnemyCount(waveIndex)], UNDEAD_KEY);
		for (int i = 0; i < enemyKeys.Length; i++) {
			if (i != 0) {
				if (i % 5 == 0) {
					enemyKeys[i] = BRUTE_KEY;
				} else if (i % 7 == 0) {
					enemyKeys[i] = SHADE_KEY;
				}
			}
		}
		return enemyKeys;
	}

	public void SpawnEnemy (Direction spawnDirection, string enemyKey) {
		if (orderedEnemyPrefabs.ContainsKey(enemyKey)) {
			GameObject enemy = (GameObject) Instantiate(orderedEnemyPrefabs[enemyKey], EnemySpawnPoint.GetPosition(spawnDirection), Quaternion.identity);
			EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            AddActiveEnemy(enemyBehaviour);
			enemyBehaviour.SetEnemy(templateUnits[enemyKey]);
			enemyBehaviour.SetTarget(worldController.ICoreOrbInstance);
			enemy.transform.SetParent(transform);
			// Placeholder: because undead is sprite;
			Quaternion angle = Quaternion.identity;
			if (enemyKey == UNDEAD_KEY) {
				angle.eulerAngles = new Vector3(90, 0, 0);
			} else {
				float yRotation = DirectionUtil.DegreesToRotate(enemyBehaviour.DirectionFacing, DirectionUtil.OppositeDirection(spawnDirection));
				angle.eulerAngles = new Vector3(0, yRotation, 0);
			}
			enemy.transform.eulerAngles = angle.eulerAngles;
		} else {
			Debug.LogErrorFormat("ERROR: No enemy of type {0}", enemyKey);
		}
	}
		
	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		} else {
			PopulateOrderedEnemyPrefabs();
		}
	}

	void PopulateOrderedEnemyPrefabs () {
		orderedEnemyPrefabs.Clear();
		foreach (GameObject enemyPrefab in EnemyPrefabs) {
			orderedEnemyPrefabs.Add(enemyPrefab.name, enemyPrefab);
		}
	}
	protected override void CleanupReferences () {
		base.CleanupReferences ();
		Instance = null;
	}

    public void AddActiveEnemy(EnemyBehaviour enemy) {
        if (!activeEnemies.Contains(enemy)) {
            activeEnemies.Add(enemy);
        }
    }

    public void RemoveActiveEnemy(EnemyBehaviour enemy) {
        if (activeEnemies.Contains(enemy)) {
            activeEnemies.Remove(enemy);
        }
    }

    public void KillAllEnemies() {
        for (int i = 0; i < activeEnemies.Count; i++) {
            activeEnemies.ElementAt(i).Destroy();
        }
        activeEnemies.Clear();
    }

    public void Create(Enemy unit) {
		throw new System.NotImplementedException();
	}

	public void Destroy(Enemy unit) {
		throw new System.NotImplementedException();
	}

     public IEnemy[] GetAll() {
		throw new System.NotImplementedException();
	}

     public IEnemyWave GetWave(int waveNumber) {
		throw new System.NotImplementedException();
	}

	void HandleEnemyKilled () {
		enemiesAlive = Mathf.Clamp(enemiesAlive - 1, 0, int.MaxValue);
		if (enemiesAlive == 0) {
			currentWaveIndex++;
			dataController.NextWave();
			SpawnWave(currentWaveIndex);
		}
		updateEnemiesAliveText();
		dataController.UpdateEnemiesKilled(1);
	}

	protected override void HandleNamedEvent (string eventName) {
		if (eventName == EventType.EnemyDestroyed) {
			HandleEnemyKilled();
		} else {
			base.HandleNamedEvent (eventName);
		}
	}

	MapTileBehaviour[] createEnemyPath (MapTileBehaviour startingTile) {
		MapQuadrant startingQudrant = startingTile.Quadrant;
		MapTileBehaviour goalTile = mapController.GetCenterTile();
		MapTileBehaviour currentTile = startingTile;
		MapTileBehaviour previousTile;
		List<MapTileBehaviour> path = new List<MapTileBehaviour>();
		Direction previousDirection = Direction.Zero;
		path.Add(startingTile);
		while (currentTile != goalTile) {
			currentTile = chooseTile(currentTile, goalTile, previousDirection);
			// previousDirection = currentTile.p
			path.Add(currentTile);
			previousTile = currentTile;
		}
		return path.ToArray();
	}

	MapTileBehaviour chooseTile (MapTileBehaviour currentTile, MapTileBehaviour goalTile, Direction previousDirection) {
		if (Random.Range(0, 1) == 1) {
			return closerTile(currentTile, goalTile);
		} else {
			return sideTile(currentTile, previousDirection);
		}
	}
		
	MapTileBehaviour closerTile (MapTileBehaviour currentTile, MapTileBehaviour goalTile) {
		switch (currentTile.Quadrant) {
		case MapQuadrant.NorthEast:
			return Or(currentTile.South, currentTile.West);
		case MapQuadrant.NorthWest:
			return Or(currentTile.South, currentTile.East);
		case MapQuadrant.SouthEast:
			return Or(currentTile.North, currentTile.West);
		case MapQuadrant.SouthWest:
			return Or(currentTile.North, currentTile.East);
		default:
			return null;
		}
	}

	MapTileBehaviour sideTile (MapTileBehaviour currentTile, Direction previousDirection) {
		Direction newDirection = previousDirection;
		while (newDirection == previousDirection || !currentTile.TileFromDirection(newDirection)) {		
			newDirection = DirectionUtil.RandomCardinalDirection();
		}
		return currentTile.TileFromDirection(newDirection);
	}

	MapTileBehaviour Or (MapTileBehaviour firstTile, MapTileBehaviour secondTile) {
		if (Random.Range(0, 1) == 1) {
			return firstTile;
		} else {
			return secondTile;
		}
	}
}
