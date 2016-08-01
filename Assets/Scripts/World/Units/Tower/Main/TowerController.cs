/*
 * Author(s): Isaiah Mann
 * Description: Controls all the towers in the game
 */

using UnityEngine;
using System.Collections;

public class TowerController : UnitController {
	public static TowerController Instance;

	#region Constructors
	public TowerController (IWorldController controller):base(controller) {

	}
	#endregion

	public void Create(ITower unit) {
		throw new System.NotImplementedException();
	}

	public void Destroy(ITower unit) {
		throw new System.NotImplementedException();
	}

	public ITower[] GetAll() {
		throw new System.NotImplementedException();
	}

	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}
}
