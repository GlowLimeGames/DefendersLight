using UnityEngine;
using System.Collections;

public class TowerController : UnitController, ITowerController {
	public static TowerController Instance;

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
