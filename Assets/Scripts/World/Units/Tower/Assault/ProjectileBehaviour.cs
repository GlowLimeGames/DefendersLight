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

	protected override void SetReferences() {
		base.SetReferences();
		StartCoroutine(TimedDestroy(maxLifespan));
	}

	protected override void FetchReferences() {
		
	}

	protected override void CleanupReferences () {
		
	}

	protected override void HandleNamedEvent (string eventName) {
		
	}

	public void SetTarget (ActiveObjectBehaviour target) {
		this._target = target;
		StartCoroutine(MoveTo(target.gameObject, 0.5f));
	}

	public override ActiveObjectBehaviour SelectTarget () {
		return this._target;
	}

	public override void MoveTo (MapLocation location) {
		
	}
		
	public override void Attack (ActiveObjectBehaviour activeAgent) {
		base.Attack (activeAgent);
	}

	void OnCollisionEnter (Collision collision) {
		if (_target == null) {
			return;
		}
		EnemyBehaviour enemy;
		if ((enemy = collision.collider.GetComponent<EnemyBehaviour>()) != null) {
			Attack(enemy);
			StartCoroutine(TimedDestroy(0.25f));
		}
	}
}
