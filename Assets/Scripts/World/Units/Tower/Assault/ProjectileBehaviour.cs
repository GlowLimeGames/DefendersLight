/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of a missile or projectile launched by an active object
 */

using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MobileAgentBehaviour {
	[SerializeField]
	float maxLifespan = 3.5f;
	ActiveObjectBehaviour _target;
	Tower tower;
	ActiveObjectBehaviour ITarget {
		get {
			return _target;
		}
	}

	protected override void SetReferences() {
		base.SetReferences();
		StartCoroutine(TimedReturnToPool(maxLifespan));
	}

	protected override void FetchReferences() {
		
	}

	protected override void CleanupReferences () {
		
	}

	protected override void HandleNamedEvent (string eventName) {
		
	}

	public override void MoveTo (MapLocation location) {
		throw new System.NotImplementedException();
	}

	// Sets the tower that spawned this projectile
	public void SetTower (Tower tower) {
		this.tower = tower;
		this.setUnit(tower);
	}

	public void SetTarget (ActiveObjectBehaviour target) {
		this._target = target;
		StartCoroutine(MoveTo(target.gameObject, 0.5f));
		StartCoroutine(DelayedAttack(target, 0.5f));
	}

	IEnumerator DelayedAttack (ActiveObjectBehaviour target, float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (target) {
			Attack(target, tower.AttackDamage);
		}
		StartCoroutine(TimedReturnToPool(0.25f));
	}

	public override void Attack (ActiveObjectBehaviour activeAgent, int damage) {
		base.Attack (activeAgent, tower.AttackDamage);
	}
		
	IEnumerator TimedReturnToPool (float waitTime = 0.5f) {
		yield return new WaitForSeconds(waitTime);
		if (ProjectilePool.Instance) {
			ProjectilePool.Instance.Give(this);
		} else {
			Destroy(gameObject);
		}
	}
}
