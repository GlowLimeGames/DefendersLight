/*
 * Author(s): Isaiah Mann
 * Description: Actions of an in game enemy
 */

using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MobileAgentBehaviour {
    protected override void SetReferences() {
		base.SetReferences();
    }

    protected override void FetchReferences() {

    }

	protected override void CleanupReferences () {
		EventController.Event(EventType.EnemyDestroyed);
	}

    protected override void HandleNamedEvent(string eventName) {
      
    }

    public override void MoveTo(MapLocation location) {
        throw new System.NotImplementedException();
    }

	public override ActiveObjectBehaviour SelectTarget() {
		throw new System.NotImplementedException();
	}

	public void SetTarget (GameObject target) {
		StartCoroutine(movementCoroutine = MoveTowardsTarget(target));
	}

	public void Halt () {
		if (movementCoroutine != null) {
			StopCoroutine(movementCoroutine);
		}
	}

	IEnumerator MoveTowardsTarget (GameObject target) {
		float stop = Random.Range(1f, 2f);
		while (target != null && Vector3.Distance(transform.position, target.transform.position) > stop) {
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.05f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForEndOfFrame();
	}

	void OnTriggerEnter (Collider collider) {
		if (!attackCooldownActive && collider.tag == "Tower") {
			TowerBehaviour tower = collider.GetComponent<TowerBehaviour>();
			Halt();
			Attack(tower);
		}
	}

	void OnTriggerStay (Collider collider) {
		if (!attackCooldownActive && collider.tag == "Tower") {
			TowerBehaviour tower = collider.GetComponent<TowerBehaviour>();
			Halt();
			Attack(tower);
		}
	}

	void OnTriggerExit (Collider collider) {

	}
}
