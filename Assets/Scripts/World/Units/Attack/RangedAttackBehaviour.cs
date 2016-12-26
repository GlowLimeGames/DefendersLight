/*
 * Author(s): Isaiah Mann
 * Description: Module for a ranged attack
 */

using UnityEngine;

public class RangedAttackBehaviour : AttackBehaviour {
	BoxCollider rangeCollider;

	protected override void SetReferences () {
		base.SetReferences ();
		rangeCollider = GetComponent<BoxCollider>();
	}

	void OnTriggerEnter (Collider collider) {
		if (isActive && parentObject.IIsActive) {
			parentObject.HandleColliderEnterTrigger(collider);
		}
	}

	void OnTriggerStay (Collider collider) {
		if (isActive && parentObject.IIsActive) {
			parentObject.HandleColliderStayTrigger(collider);
		}
	}
		
	public void SetRange (int range) {
		Vector3 parentScale = parentObject.transform.localScale;
		rangeCollider.size = new Vector3(range / parentScale.x, rangeCollider.size.y, range / parentScale.z);
	}

	public override void SetUnit (Unit unit) {
		base.SetUnit (unit);
		SetRange(unit.AttackRange);
	}
}
