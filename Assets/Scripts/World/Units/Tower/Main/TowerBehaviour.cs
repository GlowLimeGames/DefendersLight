/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a tower
 */

using UnityEngine;
using System.Collections;

public abstract class TowerBehaviour : StaticAgentBehaviour {
	Tower tower;

	[SerializeField]
	GameObject MissilePrefab;

	[SerializeField]
	int sellValue = 2;

	public void SetTower (Tower tower) {
		this.tower = tower;
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
		if (WorldController.Instance) {
			WorldController.Instance.RemoveActiveTower(this);
		}
		EventController.Event(EventType.TowerDestroyed);
	}

	protected override void FetchReferences () {

	}
		
	public void SelectTower () {
		GameUIController.Instance.SelectTower(this);
	}

	public void DeselectTower () {

	}

	public virtual void PlayBuildSound () {
		EventController.Event(EventType.BuildTower);
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

	public override void Attack(ActiveObjectBehaviour activeAgent, int damage) {
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

	public override void HandleColliderEnterTrigger (Collider collider) {
		base.HandleColliderEnterTrigger (collider);
		if (HasAttack && !attackCooldownActive) {
			if (collider.tag == EnemyController.ENEMY_TAG) {
				EnemyBehaviour enemy = collider.GetComponent<EnemyBehaviour>();
				Attack(enemy, tower.AttackDamage);
			}
		}
	}

	public override void HandleColliderStayTrigger (Collider collider)	{
		base.HandleColliderStayTrigger (collider);
		if (HasAttack && !attackCooldownActive) {
			if (collider.tag == EnemyController.ENEMY_TAG) {
				EnemyBehaviour enemy = collider.GetComponent<EnemyBehaviour>();
				Attack(enemy, tower.AttackDamage);
			}
		}
	}
}
