/*
 * Author(s): Isaiah Mann
 * Description: Controls the enemies in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class EnemyController : UnitController<IEnemy, Enemy, EnemyList>, IEnemyController {
	EventActionInt waveAdvance;
	[SerializeField]
	GameObject spawnPointPrefab;
	[SerializeField]
	Transform spawnPointParent;
	public const string ENEMY_TAG = "Enemy";
	const string UNDEAD_KEY = "Undead";
	const string BRUTE_KEY = "Brute";
	const string SHADE_KEY = "Shade";
	public GameObject[] EnemyPrefabs;
	Dictionary<string, GameObject> orderedEnemyPrefabs = new Dictionary<string, GameObject>();
	List<EnemySpawnPoint> spawnPoints;
	public static EnemyController Instance;
	int enemiesAlive = 0;
	int currentWaveIndex = 1;
	int spawnPointCount = 1;
	EnemyWave currentWave = null;
	public EnemyWave ICurrentWave {
		get {
			return this.currentWave;
		}
	}

	MathEquation spawnCountEquation = LinearEquation.Default;
    HashSet<EnemyBehaviour> activeEnemies = new HashSet<EnemyBehaviour>();
	public int ICurrentWaveIndex {
		get {
			return currentWaveIndex;
		}
	}

	public virtual void Setup (WorldController worldController, DataController dataController, MapController mapController, string unitTemplateJSONPath, MathEquation spawnCountEquation) {
		base.Setup(worldController, dataController, mapController, unitTemplateJSONPath);
		if (inGame) {
			this.spawnCountEquation = spawnCountEquation;
			createSpawnPoints();
		}
	}

	public EnemyBehaviour GetPrefab (string enemyKey) {
		return loadPrefab(FileUtil.CreatePath(ENEMY_TAG, PREFABS_DIR, enemyKey)) as EnemyBehaviour;
	}

	#region Spawn Points

	void createSpawnPoints () {
		spawnPoints = new List<EnemySpawnPoint>();
		for (int i = 0; i < spawnPointCount; i++) {
			MapQuadrant spawnQuadrant = (MapQuadrant) (i % 4);
			spawnPoints.Add(createNewSpawnPoint());
			spawnPoints[i].Setup(spawnQuadrant);
		}
	}

	EnemySpawnPoint createNewSpawnPoint () {
		GameObject spawnPoint = Instantiate(spawnPointPrefab) as GameObject;
		spawnPoint.transform.SetParent(spawnPointParent);
		return spawnPoint.GetComponent<EnemySpawnPoint>();
	}
		
	void refreshSpawnPointsForWave () {
		foreach (EnemySpawnPoint spawnPoint in spawnPoints) {
			spawnPoint.ChooseStartingTile();
			spawnPoint.SetPath(createEnemyPath(spawnPoint.Tile));
		}
	}
		
	void updateSpawnPoints () {
		int currentSpawnPoints = spawnPoints.Count;
		if (currentSpawnPoints > spawnPointCount) {
			int countToRemove = currentSpawnPoints - spawnPointCount;
			removeSpawnPoints(countToRemove);
		} else if (currentSpawnPoints < spawnPointCount) {
			int countToAdd = spawnPointCount - currentSpawnPoints;
			addSpawnPoints(countToAdd);
		}
	}

	void addSpawnPoints (int countToAdd) {
		for (int i = 0; i < countToAdd; i++) {
			EnemySpawnPoint spawnPoint = createNewSpawnPoint();
			spawnPoint.Setup((MapQuadrant) (spawnPoints.Count % 4));
			spawnPoints.Add(spawnPoint);
		}
	}

	void removeSpawnPoints (int countToRemove) {
		spawnPoints.RemoveRange(0, countToRemove);
	}

	#endregion

	public void SpawnWave () {
		SpawnWave(currentWaveIndex);
	}

	public void SetSpawnPointCount (int spawnPointCount) {
		this.spawnPointCount = spawnPointCount;
		if (spawnPoints != null) {
			updateSpawnPoints();
		}
	}

	public void SpawnWave (int waveIndex) {
		refreshSpawnPointsForWave();
		StatsPanelController.Instance.SetWave(waveIndex);
		callOnWaveAdvance(waveIndex);
		// TODO: Implement non-placeholder functionality
		StartCoroutine(RunSpawnWave(waveIndex, 0.5f));
		EventController.Event(EventType.EnemiesApproaching);
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
		enemiesAlive += enemiesInWaveCount;
		string[] enemyTypes = GetEnemyTypes(waveIndex);
		for (int i = 0; i < enemiesInWaveCount; i++) {
			SpawnEnemy(randomSpawnPoint(), (Direction)(i%4), enemyTypes[i]);
			yield return new WaitForSeconds(spawnDelay);
		}
		updateEnemiesAliveText();
	}

	EnemySpawnPoint randomSpawnPoint () {
		return spawnPoints[Random.Range(0, spawnPoints.Count)];
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

	public void SpawnEnemy (EnemySpawnPoint spawnPoint, Direction spawnDirection, string enemyKey) {
		if (orderedEnemyPrefabs.ContainsKey(enemyKey)) {
			EnemyBehaviour enemyBehaviour = GetEnemyObject(enemyKey, spawnPoint.GetPosition());
			enemyBehaviour.Setup(this);
			GameObject enemy = enemyBehaviour.gameObject;
			enemyBehaviour.ToggleColliders(true);
            AddActiveEnemy(enemyBehaviour);
			enemyBehaviour.SetEnemy(templateUnits[enemyKey]);
			enemyBehaviour.SetPath(new Queue<MapTileBehaviour>(spawnPoint.CurrentPath));
			enemyBehaviour.SetOffset(new Vector3(Random.Range(0, 0.2f), 0, Random.Range(0, 0.2f)));
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
			enemyBehaviour.OnSpawn();
			enemyBehaviour.NavigatePath();
		} else {
			Debug.LogErrorFormat("ERROR: No enemy of type {0}", enemyKey);
		}
	}
		
	EnemyBehaviour GetEnemyObject (string enemyKey, Vector3 startPosition) {
		ActiveObjectBehaviour behaviour;
		if (!TryGetActiveObject(enemyKey, startPosition, out behaviour)) {
			EnemyBehaviour enemyPrefab = GetPrefab(enemyKey);
			if (enemyPrefab) {
				behaviour = Instantiate(enemyPrefab);
			} else {
				behaviour = Instantiate(orderedEnemyPrefabs[enemyKey]).GetComponent<EnemyBehaviour>();

			}
			behaviour.transform.position = startPosition;
		}
		return behaviour as EnemyBehaviour;
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

	public override void HandleObjectDestroyed (ActiveObjectBehaviour activeObject) {
		base.HandleObjectDestroyed (activeObject);
		activeEnemies.Remove(activeObject as EnemyBehaviour);
	}

	void HandleEnemyKilled () {
		enemiesAlive = Mathf.Clamp(enemiesAlive - 1, 0, int.MaxValue);
		if (enemiesAlive == 0) {
			transitionToNextWave();
		}
		updateEnemiesAliveText();
		dataController.UpdateEnemiesKilled(1);
	}

	void transitionToNextWave () {
		currentWaveIndex++;
		worldController.StartWave();
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
		MapTileBehaviour previousTile = null;
		List<MapTileBehaviour> path = new List<MapTileBehaviour>();
		Direction previousDirection = Direction.Zero;
		path.Add(startingTile);
		while (currentTile != goalTile) {
			while (path.Contains(currentTile)) {
				currentTile = chooseTile(currentTile, goalTile, previousDirection);
			}
			path.Add(currentTile);
			if (currentTile && previousTile) {
				previousDirection = currentTile.GetDirection(previousTile);
			}
			previousTile = currentTile;
		}
		return path.ToArray();
	}

	MapTileBehaviour chooseTile (MapTileBehaviour currentTile, MapTileBehaviour goalTile, Direction previousDirection) {
		if (Random.Range(0.0f, 1.0f) >= 0.25f) {
			return closerTile(currentTile, goalTile);
		} else {
			return sideTile(currentTile, previousDirection);
		}
	}

	MapTileBehaviour closerTile (MapTileBehaviour currentTile, MapTileBehaviour goalTile) {
		if (currentTile.X > goalTile.X) {
			return currentTile.West;
		} else if (currentTile.X < goalTile.X) {
			return currentTile.East;
		} else if (currentTile.Y > goalTile.Y) {
			return currentTile.South;
		} else if (currentTile.Y < goalTile.Y) {
			return currentTile.North;
		} else {
			return goalTile;
		}
	}

	MapTileBehaviour sideTile (MapTileBehaviour currentTile, Direction previousDirection) {
		Direction newDirection = previousDirection;
		while (newDirection == previousDirection || !currentTile.TileFromDirection(newDirection)) {		
			newDirection = DirectionUtil.RandomCardinalDirection();
		}
		return currentTile.TileFromDirection(newDirection);
	}

	public IEnemyWave GetWave(int waveNumber) {
		throw new System.NotImplementedException();
	}

	public Sprite GetEnemySprite (string enemyKey) {
		// Remove special characters from tower key (to produce filename)
		Regex rgx = new Regex("[^a-zA-Z0-9 -]");
		enemyKey = rgx.Replace(enemyKey, "");
		return Resources.Load<Sprite>(System.IO.Path.Combine(ENEMY_TAG, System.IO.Path.Combine(SPRITES_DIR, enemyKey.ToLower().Replace(" ", string.Empty))));
	}
}
