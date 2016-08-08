/*
 * Author(s): Isaiah Mann
 * Description: Controls the enemies in the game
 */

using UnityEngine;
using System.Collections;

public class EnemyController : UnitController, IEnemyController {
	public static EnemyController Instance;

	#region Constructors
	public EnemyController (IWorldController controller):base(controller) {

	}
	#endregion

	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}

	public void Create(IUnit unit) {
		throw new System.NotImplementedException();
	}

	public void Destroy(IUnit unit) {
		throw new System.NotImplementedException();
	}

     public IEnemy[] GetAll() {
		throw new System.NotImplementedException();
	}

     public IEnemyWave GetWave(int waveNumber) {
		throw new System.NotImplementedException();
	}
}
