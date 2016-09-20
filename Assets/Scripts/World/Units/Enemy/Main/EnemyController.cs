/*
 * Author(s): Isaiah Mann
 * Description: Controls the enemies in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : UnitController<IEnemy, Enemy, EnemyList>, IEnemyController {
	public const string ENEMY_TAG = "Enemy";
	public static EnemyController Instance;
	int enemiesAlive = 0;
	int currentWave = 1;
	public int ICurrentWave {
		get {
			return currentWave;
		}
	}

	public void SpawnWave () {
		SpawnWave(currentWave);
	}

	public void SpawnWave (int waveIndex) {
		StatsPanelController.Instance.SetWave(waveIndex);
		// TODO: Implement non-placeholder functionality
		StartCoroutine(RunSpawnWave(waveIndex, 0.5f));
	}

	IEnumerator RunSpawnWave (int waveIndex, float spawnDelay) {
		int enemiesInWaveCount = GetEnemyCount(waveIndex);
		enemiesAlive += enemiesInWaveCount;
		for (int i = 0; i < enemiesInWaveCount; i++) {
			SpawnEnemy((Direction)(i%4));
			yield return new WaitForSeconds(spawnDelay);
		}
		updateEnemiesAliveText();
	}

	void updateEnemiesAliveText () {
		StatsPanelController.Instance.SetEnemies(enemiesAlive);
	}

	int GetEnemyCount (int waveIndex) {
		// TODO: Implement actual difficulty curve
		return waveIndex;
	}
	public void SpawnEnemy (Direction spawnDirection) {
		Quaternion angle = Quaternion.identity;
		angle.eulerAngles = new Vector3(90, 0, 0);
		GameObject enemy = (GameObject) Instantiate(worldController.EnemyPrefab, EnemySpawnPoint.GetPosition(spawnDirection), angle);
		enemy.GetComponent<EnemyBehaviour>().SetTarget(worldController.ICoreOrbInstance);
		enemy.transform.SetParent(transform);
	}
		
	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}

	protected override void CleanupReferences () {
		base.CleanupReferences ();
		Instance = null;
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
			currentWave++;
			SpawnWave(currentWave);
		}
		updateEnemiesAliveText();
	}

	protected override void HandleNamedEvent (string eventName) {
		if (eventName == EventType.EnemyDestroyed) {
			HandleEnemyKilled();
		} else {
			base.HandleNamedEvent (eventName);
		}
	}
}
