using UnityEngine;
using System.Collections;

public class EnemyController : UnitController {

	public static EnemyController Instance;

	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}
}
