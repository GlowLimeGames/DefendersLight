/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of a missile or projectile launched by an active object
 */

using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MobileAgentBehaviour {
	public override string IType {
		get {
			return Name;
		}
	}
	[SerializeField]
	float maxLifespan = 3.5f;
	public float IMaxLifeSpan {
		get {
			return maxLifespan;
		}
	}
	ActiveObjectBehaviour _target;
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
		world = WorldController.Instance;
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
		checkToUnsubscribeCleanup();
	}

	protected override void HandleNamedEvent (string eventName) {
		// NOTHING
	}

	public override void MoveTo (MapLocation location) {
		throw new System.NotImplementedException();
	}
	public void SetTarget (ActiveObjectBehaviour target) {
		this._target = target;
		this._target.SubscribeToDestruction(cleanup);
		StartCoroutine(MoveTo(target.gameObject, 0.5f));
		StartCoroutine(DelayedAttack(target, 0.5f));
	}

	void checkToUnsubscribeCleanup () {
		// Don't try to call the cleanup method if this object has destroyed
		if (_target) {
			_target.UnusubscribeFromDestruction(cleanup);
		}
	}

	void cleanup () {
		checkToUnsubscribeCleanup();
		StopAllCoroutines();
		tryReclaimInSpawnPool();
	}

	bool tryReclaimInSpawnPool () {
		if (world) {
			world.AddToSpawnPool(this);
			return true;
		} else {
			return false;
		}
	}

	IEnumerator DelayedAttack (ActiveObjectBehaviour target, float waitTime) {
		yield return new WaitForSeconds(waitTime);
		if (target) {
			Attack(target, unit.AttackDamage);
		}
		if (isActiveAndEnabled) StartCoroutine(TimedReturnToPool(0.25f));
	}

	public override void Attack (ActiveObjectBehaviour activeAgent, int damage) {
		base.Attack (activeAgent, unit.AttackDamage);
	}
		
	IEnumerator TimedReturnToPool (float waitTime = 0.5f) {
		yield return new WaitForSeconds(waitTime);
		tryReclaimInSpawnPool();
	}
}
