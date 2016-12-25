/*
 * Author(s): Isaiah Mann
 * Description: Controls the enemies in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System;
// Abbreviation to specify which Random class we're using: UE.Random == UnityEngine.Random
using UE = UnityEngine;

public class EnemyController : UnitController<IEnemy, Enemy, EnemyList>, IEnemyController {
	static bool debugSpawnAllAtWave1 = false;
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
	List<EnemySpawnPoint> spawnPoints;
	EnemySorter enemySorter = new EnemySpawnLevelSorter();
	List<Enemy> enemiesBySpawnLevel;
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

	public virtual void Setup (
		WorldController worldController, 
		DataController dataController, 
		MapController mapController, 
		string unitTemplateJSONPath, 
		MathEquation spawnCountEquation) {
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

	void sortEnemiesBySpawnLevel () {
		enemiesBySpawnLevel = new List<Enemy>(templateUnits.Values);
		enemiesBySpawnLevel.Sort(enemySorter.Compare);
		// Debugging method to test different enemies at Wave 1 (remove for production builds)
		if (debugSpawnAllAtWave1) {
			foreach (Enemy e in enemiesBySpawnLevel) {
				e.WaveSpawnedAt = 1;
			}
		}
	}

	public override void CreateUnitTemplates (string jsonText) {
		base.CreateUnitTemplates (jsonText);
		// Used for the spawning algorithm
		sortEnemiesBySpawnLevel();
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
		return spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)];
	}

	void updateEnemiesAliveText () {
		StatsPanelController.Instance.SetEnemies(enemiesAlive);
	}

	int GetEnemyCount (int waveIndex) {
		// TODO: Implement actual difficulty curve
		return spawnCountEquation.CalculateAsInt(waveIndex);
	}

    public void setWave(int waveIndex) {
        currentWaveIndex = waveIndex;
        KillAllEnemies();
        SpawnWave();
    }

	string[] GetEnemyTypes (int waveIndex, bool shouldShuffle = true) {
		int remainingEnemiesToSpawn = spawnCountEquation.CalculateAsInt(waveIndex);
		List<string> wave = new List<string>();
		for (int i = enemiesBySpawnLevel.Count - 1; i >= 0; i--) {
			if (remainingEnemiesToSpawn <= 0) {
				break;
			}
			Enemy enemy = enemiesBySpawnLevel[i];
			int numberOfType;
			if (enemy.IsGruntType) {
				numberOfType = remainingEnemiesToSpawn; 
			} else {
				numberOfType = determineEnemyCountInWave(waveIndex, enemy);
				numberOfType = Mathf.Clamp(numberOfType, 0, remainingEnemiesToSpawn);
				remainingEnemiesToSpawn -= numberOfType;
			}
			wave.AddRange(Enumerable.Repeat(enemy.Type, numberOfType));
		}
		if (shouldShuffle) {
			wave.OrderBy(random => Guid.NewGuid());
		}
		return wave.ToArray();
	}

	int determineEnemyCountInWave (int waveIndex, Enemy enemy) {
		if (waveIndex < enemy.WaveSpawnedAt) {
			return 0;
		} else {
			int range = waveIndex - enemy.WaveSpawnedAt;
			int zeroOffset = 1;
			return enemy.Quantity * (range / enemy.Frequency + zeroOffset);
		}
	}
	public void SpawnEnemy (Enemy enemy) {
		try {
			MapTileBehaviour tile = mapController.GetTileFromLocation(enemy.Location);
			EnemyBehaviour enemyBehaviour = GetEnemyObject(enemy.Type, tile.GetWorldPosition());
			enemyBehaviour.Setup(this);
			GameObject enemyObject = enemyBehaviour.gameObject;
			enemyBehaviour.ToggleColliders(true);
			enemyBehaviour.SetEnemy(enemy);
			enemyBehaviour.SetPath(new Queue<MapTileBehaviour>(createEnemyPath(tile)));
			enemyBehaviour.SetOffset(new Vector3(UE.Random.Range(0, 0.2f), 0, UE.Random.Range(0, 0.2f)));
			enemyObject.transform.SetParent(transform);
			// Placeholder: because undead is sprite;
			Quaternion angle = Quaternion.identity;
			enemyBehaviour.DirectionFacing = getDirectionFacing(
				mapController.GetTileFromLocation(enemy.Location).GetWorldPosition(),
				worldController.ICoreOrbInstance.transform.position);
			float yRotation = DirectionUtil.GetAngleFromDirection(enemyBehaviour.DirectionFacing);
			angle.eulerAngles = new Vector3(0, yRotation, 0);
			enemyObject.transform.eulerAngles = angle.eulerAngles;
			enemyBehaviour.OnSpawn();
			enemyBehaviour.NavigatePath();
			AddActiveEnemy(enemyBehaviour);
		} catch {
			Debug.LogErrorFormat("ERROR: No enemy of type {0}", enemy.Type);
		}
	}

	public void SpawnEnemy (EnemySpawnPoint spawnPoint, Direction spawnDirection, string enemyKey) {
		try {
			EnemyBehaviour enemyBehaviour = GetEnemyObject(enemyKey, spawnPoint.GetPosition());
			enemyBehaviour.Setup(this);
			GameObject enemy = enemyBehaviour.gameObject;
			enemyBehaviour.ToggleColliders(true);
			Enemy enemyClone = new Enemy(templateUnits[enemyKey]);
			enemyBehaviour.SetEnemy(enemyClone);
			enemyBehaviour.SetPath(new Queue<MapTileBehaviour>(spawnPoint.CurrentPath));
			enemyBehaviour.SetOffset(new Vector3(UE.Random.Range(0, 0.2f), 0, UE.Random.Range(0, 0.2f)));
			enemy.transform.SetParent(transform);
			// Placeholder: because undead is sprite;
			Quaternion angle = Quaternion.identity;
			enemyBehaviour.DirectionFacing = getDirectionFacing(spawnPoint.GetPosition(), worldController.ICoreOrbInstance.transform.position);
			float yRotation = DirectionUtil.GetAngleFromDirection(enemyBehaviour.DirectionFacing);
			angle.eulerAngles = new Vector3(0, yRotation, 0);
			enemy.transform.eulerAngles = angle.eulerAngles;
			enemyBehaviour.OnSpawn();
			enemyBehaviour.NavigatePath();
			AddActiveEnemy(enemyBehaviour);
		} catch {
			Debug.LogErrorFormat("ERROR: No enemy of type {0}", enemyKey);
		}
	}
		
	Direction getDirectionFacing (Vector3 position, Vector3 coreOrbPosition) {
		Vector3 difference = position - coreOrbPosition;
		if (Mathf.Abs(position.x - coreOrbPosition.x) > Mathf.Abs(position.y - coreOrbPosition.y)) {
			if (difference.x > 0) {
				return Direction.East;
			} else {
				return Direction.West;
			}
		} else {
			if (difference.y > 0) {
				return Direction.South;
			} else {
				return Direction.North;
			}
		}
	}

	EnemyBehaviour GetEnemyObject (string enemyKey, Vector3 startPosition) {
		ActiveObjectBehaviour behaviour;
		if (!TryGetActiveObject(enemyKey, startPosition, out behaviour)) {
			EnemyBehaviour enemyPrefab = GetPrefab(enemyKey);
			if (enemyPrefab) {
				behaviour = Instantiate(enemyPrefab);
			} else {
				Debug.LogErrorFormat("Cannot Find Enemy of Type {0}", enemyKey);
				return null;

			}
			behaviour.transform.position = startPosition;
		}
		return behaviour as EnemyBehaviour;
	}

	protected override void SetReferences() {
		if (SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			_activeUnits = new List<Enemy>();
		} else {
			Destroy(gameObject);
		}
	}

	protected override void CleanupReferences () {
		base.CleanupReferences ();
		Instance = null;
	}

    public void AddActiveEnemy(EnemyBehaviour enemy) {
        if (!activeEnemies.Contains(enemy)) {
            activeEnemies.Add(enemy);
			_activeUnits.Add(enemy.IEnemy);
        }
    }

    public void RemoveActiveEnemy(EnemyBehaviour enemy) {
        if (activeEnemies.Contains(enemy)) {
            activeEnemies.Remove(enemy);
			_activeUnits.Remove(enemy.IEnemy);
        }
    }

	// Worth checking so we can end the wave if only shades remain
	public bool OnlyNonLethalEnemiesAlive () {
		bool onlyNonLethal = true;
		foreach (EnemyBehaviour enemy in activeEnemies) {
			onlyNonLethal &= enemy is ShadeBehaviour;
			if (!onlyNonLethal) {
				return false;
			}
		}
		// Will always be true if it reaches this point
		return onlyNonLethal;
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
		if (OnlyNonLethalEnemiesAlive()) {
			// Kills any shades still alive (because otherwise it slows down the gameflow unecessarily
			KillAllEnemies();
		}
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

	MapTileBehaviour[] createEnemyPath (MapTileBehaviour startingTile, MapTileBehaviour customDestination = null, bool includeDestinationTile = true) {
		MapQuadrant startingQudrant = startingTile.Quadrant;
		MapTileBehaviour goalTile;
		if (customDestination == null) {
			goalTile = mapController.GetCenterTile();
		} else {
			goalTile = customDestination;
		}
		MapTileBehaviour currentTile = startingTile;
		MapTileBehaviour previousTile = null;
		List<MapTileBehaviour> path = new List<MapTileBehaviour>();
		Direction previousDirection = Direction.Zero;
		path.Add(startingTile);
		while (currentTile != goalTile) {
			while (path.Contains(currentTile)) {
				currentTile = chooseTile(currentTile, goalTile, previousDirection);
			}
			// Don't add the actual goal tile: the enemy should just walk one square away from it
			if (includeDestinationTile || currentTile != goalTile) {
				path.Add(currentTile);
			}
			if (currentTile && previousTile) {
				previousDirection = currentTile.GetDirection(previousTile);
			}
			previousTile = currentTile;
		}
		return path.ToArray();
	}

	MapTileBehaviour chooseTile (MapTileBehaviour currentTile, MapTileBehaviour goalTile, Direction previousDirection) {
		if (UE.Random.Range(0.0f, 1.0f) >= 0.25f) {
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
