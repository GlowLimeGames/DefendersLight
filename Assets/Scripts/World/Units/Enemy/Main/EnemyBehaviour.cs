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

	}

    protected override void HandleNamedEvent(string eventName) {
      
    }

	public override void Attack(ActiveObjectBehaviour activeAgent) {
		base.Attack(activeAgent);
    }

	public override void Damage(int damage) {
		base.Damage(damage);
	}

	public override void Destroy() {
		base.Destroy();
	}

	public override void Heal(int healthPoints) {
		base.Heal(healthPoints);
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
		while (Vector3.Distance(transform.position, target.transform.position) > stop) {
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.05f);
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForEndOfFrame();
	}

	void OnCollisionEnter (Collision collision) {
		TowerBehaviour tower;
		if ((tower = collision.collider.GetComponent<TowerBehaviour>()) != null) {
			Halt();
			Attack(tower);
		}
	}
}
