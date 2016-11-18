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
		if (isActive) {
			parentObject.HandleColliderEnterTrigger(collider);
		}
	}

	void OnTriggerStay (Collider collider) {
		if (isActive) {
			parentObject.HandleColliderStayTrigger(collider);
		}
	}
		
	public void SetRange (int range) {
		rangeCollider.size = new Vector3(range, rangeCollider.size.y, range);
	}

	public override void SetUnit (Unit unit) {
		base.SetUnit (unit);
		SetRange(unit.AttackRange);
	}
}
