/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of the shade enemy
 */

using UnityEngine;
using System.Collections;

public class ShadeBehaviour : EnemyBehaviour {
	public int HealRate;
	public int HealCooldown;
	public int HealthDrainPerTick = 1;
	public float HealthDrainDelay = 1f;
	bool healingIsCoolingDown = false;

	protected override void SetReferences () {
		base.SetReferences ();
		StartCoroutine(healthDrain());
	}

	protected override bool canHealTarget (ActiveObjectBehaviour target) {
		return base.canHealTarget(target) && isEnemy(target);
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == TowerController.TOWER_TAG && isMoving) {
			Halt();
		} else {
			checkToHeal(collider);	
		}
	}
		
	void OnTriggerStay (Collider collider) {
		if (collider.gameObject.tag == TowerController.TOWER_TAG && isMoving) {
			Halt();
		} else {
			checkToHeal(collider);	
		}
	}

	void checkToHeal (Collider collider) {
		if (!healingIsCoolingDown) {
			ActiveObjectBehaviour activeObject = collider.GetComponent<ActiveObjectBehaviour>();
			if (activeObject != null && canHealTarget(activeObject)) {
				HealTarget(activeObject, Mathf.Clamp(HealRate, 0, Health));
			}
		}
	}

	public override bool CanDamage (ActiveObjectBehaviour attacker) {
		return attacker.AttackType == AttackType.Energy;
	}

	public override void HealTarget (ActiveObjectBehaviour target, int healthPoints) {
		base.HealTarget (target, healthPoints);
		Damage(healthPoints);
		healingIsCoolingDown = true;
		StartCoroutine(startHealingCooldown(HealCooldown));
		if (isMoving) {
			Halt();
		}
	}

	IEnumerator startHealingCooldown (float cooldownTime) {
		yield return new WaitForSeconds(cooldownTime);
		healingIsCoolingDown = false;
	}

	IEnumerator healthDrain () {
		while (gameObject) {
			yield return new WaitForSeconds(HealthDrainDelay);
			Damage(HealthDrainPerTick);
		}
	}
}
