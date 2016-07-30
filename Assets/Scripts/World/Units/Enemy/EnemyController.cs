/*
 * Author(s): Isaiah Mann
 * Description: Controls the enemies in the game
 */

using UnityEngine;
using System.Collections;

public class EnemyController : UnitController {

	public static EnemyController Instance;

	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}

	public void Create(IEnemy unit) {
		throw new System.NotImplementedException();
	}

     public void Destroy(IEnemy unit) {
		throw new System.NotImplementedException();
	}

     public IEnemy[] GetAll() {
		throw new System.NotImplementedException();
	}

     public IEnemyWave GetWave(int waveNumber) {
		throw new System.NotImplementedException();
	}

}
