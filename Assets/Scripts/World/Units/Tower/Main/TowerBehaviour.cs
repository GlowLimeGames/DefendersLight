/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a tower
 */

using UnityEngine;
using System.Collections;

public abstract class TowerBehaviour : StaticAgentBehaviour {

	[SerializeField]
	GameObject MissilePrefab;

	[SerializeField]
	int sellValue = 2;

	protected override void CleanupReferences () {
		if (WorldController.Instance) {
			WorldController.Instance.RemoveActiveTower(this);
		}
		EventController.Event(EventType.TowerDestroyed);
	}

	protected override void FetchReferences () {

	}
		
	public void SelectTower () {
		UIController.Instance.SelectTower(this);
	}

	public void DeselectTower () {

	}

	public override ActiveObjectBehaviour SelectTarget() {
		return null;
	}

	protected override void HandleNamedEvent (string eventName) {

	}

	public void Sell () {
		WorldController.Instance.CollectMiniOrbs(sellValue);
		Destroy(gameObject);
	}

	public override void Attack(ActiveObjectBehaviour activeAgent) {
		StartCoroutine(AttackCooldown());
		ProjectileBehaviour missileBehavior;
		if (ProjectilePool.Instance && !ProjectilePool.Instance.IsEmpty) {
			missileBehavior = ProjectilePool.Instance.Take();
			missileBehavior.transform.position = transform.position;
		} else {
			missileBehavior = ((GameObject) Instantiate(MissilePrefab, transform.position, Quaternion.identity)).GetComponent<ProjectileBehaviour>();
		}
		missileBehavior.SetTarget(activeAgent);
	}

	void OnTriggerEnter (Collider collider) {
		if (HasAttack && !attackCooldownActive) {
			if (collider.tag == "Enemy") {
				EnemyBehaviour enemy = collider.GetComponent<EnemyBehaviour>();
				Attack(enemy);
			}
		}
	}

	void OnTriggerStay (Collider collider) {
	 	if (HasAttack && !attackCooldownActive) {
			if (collider.tag == "Enemy") {
				EnemyBehaviour enemy = collider.GetComponent<EnemyBehaviour>();
				Attack(enemy);
			}
		}
	}

}
