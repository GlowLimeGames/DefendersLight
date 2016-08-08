/*
 * Author(s): Isaiah Mann
 * Description: Controls the enemies in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : UnitController<IEnemy>, IEnemyController {
	public static EnemyController Instance;

	#region Constructors

	public EnemyController (IWorldController controller, string unitTemplateJSON):base(controller, unitTemplateJSON) {

	}

	#endregion

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

	public override void CreateUnitTemplates (string jsonText) {
		throw new System.NotImplementedException ();
	}
}
