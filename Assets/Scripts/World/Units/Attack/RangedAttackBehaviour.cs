/*
 * Author(s): Isaiah Mann
 * Description: Module for a ranged attack
 */

using UnityEngine;

public class RangedAttackBehaviour : AttackBehaviour {
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
}
