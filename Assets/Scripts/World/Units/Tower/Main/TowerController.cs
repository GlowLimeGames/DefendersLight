/*
 * Author(s): Isaiah Mann
 * Description: Controls all the towers in the game
 */

using UnityEngine;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;

public class TowerController : UnitController<ITower, Tower, TowerList>, ITowerController {
	public static TowerController Instance;

	public Tower[] GetActive() {
		throw new System.NotImplementedException ();
	}

	public void Create(Tower unit) {
		throw new System.NotImplementedException();
	}

	public void Destroy(Tower unit) {
		throw new System.NotImplementedException();
	}

	public Tower[] GetAll() {
		throw new System.NotImplementedException();
	}

	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}
}
