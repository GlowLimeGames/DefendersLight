/*
 * Author(s): Isaiah Mann
 * Description: Controls the enemies in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : UnitController<IEnemy, Enemy, EnemyList>, IEnemyController {
	public static EnemyController Instance;

	public void SpawnWave (int waveIndex) {
		// TODO: Implement non-placeholder functionality
		StartCoroutine(RunSpawnWave(waveIndex, 0.5f));
	}

	IEnumerator RunSpawnWave (int waveIndex, float spawnDelay) {
		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy((Direction)(i%4));
			yield return new WaitForSeconds(spawnDelay);
		}
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
}
