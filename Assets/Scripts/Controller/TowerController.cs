using UnityEngine;
using System.Collections;

public class TowerController : UnitController {
	public static TowerController Instance;

	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}	
}
