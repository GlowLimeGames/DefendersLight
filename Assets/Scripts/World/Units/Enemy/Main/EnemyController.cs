/*
 * Author(s): Isaiah Mann
 * Description: Controls the enemies in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : UnitController<IEnemy, Enemy, EnemyList>, IEnemyController {
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

	public void CreateUnitTemplates (string jsonText) {
		throw new System.NotImplementedException ();
	}
}
