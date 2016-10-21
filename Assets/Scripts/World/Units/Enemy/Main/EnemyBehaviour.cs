/*
 * Author(s): Isaiah Mann
 * Description: Actions of an in game enemy
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehaviour : MobileAgentBehaviour {
	public Direction DirectionFacing;
	TowerBehaviour previousTarget;
	Enemy enemy;
	public override string IName {
		get {
			return enemy.Type;
		}
	}
	public override float IAttackDelay {
		get {
			return enemy.AttackCooldown;
		}
	}
	public override int IMaxHealth {
		get {
			return enemy.Health;
		}
	}
    public int ISpeed{
        get{
            return enemy.Speed;
        }
    }
	public bool HasPath {
		get {
			return path != null && path.Count > 0;
		}
	}
	float _placeholderMovementSpeed = 0.5f;
	float movementSpeed {
		get {
			// TODO: Implement actual speed value in JSON
			return _placeholderMovementSpeed;
		}
	}

	Queue<MapTileBehaviour> path = null;

	public void SetEnemy (Enemy enemy) {
		this.enemy = enemy;
		setUnit(enemy);
	}

	public void SetPath (Queue<MapTileBehaviour> path) {
		this.path = path;
	}
		
	protected override void updateCurrentLocation (MapTileBehaviour currentTile) {
		base.updateCurrentLocation (currentTile);
	}

	protected override void FetchReferences() {}

	protected override void CleanupReferences () {
		base.CleanupReferences();
		EventController.Event(EventType.EnemyDestroyed);
		EventController.Event(EventType.EnemyDestroyed, enemy);
		if (WorldController.Instance) {
			WorldController.Instance.RemoveActiveEnemy(this);
		}
	}

    protected override void HandleNamedEvent(string eventName) {}

		
	void ResumeMoving () {
		if (this && WorldController.Instance && WorldController.Instance.ICoreOrbInstance != null) {
			NavigatePath();
		}
	}
		
	public void NavigatePath () {
		if (path != null) {
			NavigatePath(path, movementSpeed);
		}
	}

    public override void MoveTo(MapLocation location) {
		if (WorldController.Instance && WorldController.Instance.ICoreOrbInstance != null) {
			SetTarget(WorldController.Instance.ICoreOrbInstance);
		}
    }

	public override ActiveObjectBehaviour SelectTarget() {
		throw new System.NotImplementedException();
	}

	public void SetTarget (GameObject target) {
		if (this != null && gameObject != null) {
			if (gameObject.activeInHierarchy) {
				StartCoroutine(movementCoroutine = MoveTowardsTarget(target));
				isMoving = true;
			}
		}
	}

	public void Halt () {
		if (movementCoroutine != null) {
			StopCoroutine(movementCoroutine);
			isMoving = false;
		}
	}

	public override void Attack (ActiveObjectBehaviour activeAgent, int damage) {
		base.Attack (activeAgent, damage);
		EventController.Event(EventType.EnemiesDealDamage);
	}

	public override void Damage (int damage) {
		base.Damage (damage);
		EventController.Event(EventType.EnemiesTakeDamage);
	}

	IEnumerator MoveTowardsTarget (GameObject target) {
		float stop = Random.Range(0.1f, 0.5f);
		while (target != null && Vector3.Distance(transform.position, target.transform.position) > stop) {
			if (!WorldController.Instance.IsPaused) {
				transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.05f);
			}
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForEndOfFrame();
	}

	void OnTriggerEnter (Collider collider) {
		checkToAttack(collider);
	}

	void OnTriggerStay (Collider collider) {
		checkToAttack(collider);
	}

	void checkToAttack (Collider collider) {
		if (CanAttack(collider)) {
			TowerBehaviour currentTarget = collider.GetComponent<TowerBehaviour>();
			Halt();
			Attack(currentTarget, enemy.AttackDamage);
			if (previousTarget != currentTarget) {
				currentTarget.SubscribeToDestruction(ResumeMoving);
				previousTarget = currentTarget;
			}
		}
	}
		
	bool CanAttack (Collider unit) {
		return !attackCooldownActive && unit.tag == TowerController.TOWER_TAG;
	}

	protected bool isEnemy (ActiveObjectBehaviour activeObject) {
		return activeObject.gameObject.tag.Equals(EnemyController.ENEMY_TAG);
	}
}
