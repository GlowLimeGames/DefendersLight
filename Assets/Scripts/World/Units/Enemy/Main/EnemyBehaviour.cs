/*
 * Author(s): Isaiah Mann
 * Description: Actions of an in game enemy
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehaviour : MobileAgentBehaviour {
	const float K_SPEED = 0.5f;
	public Direction DirectionFacing;
	TowerBehaviour previousTarget;
	Enemy enemy;
	public override int IMaxHealth {
		get {
			if (enemy != null) {
				return enemy.Health;
			} else {
				return 0;
			}
		}
	}
    public float ISpeed{
        get{
            return enemy.Speed;
        }
    }
	public bool HasPath {
		get {
			return path != null && path.Count > 0;
		}
	}
	float movementSpeed {
		get {
			return K_SPEED / enemy.Speed;
		}
	}

	protected Queue<MapTileBehaviour> path = null;

	public Enemy IEnemy {
		get {
			return enemy;
		}
	}

	public void SetEnemy (Enemy enemy) {
		this.enemy = enemy;
		setUnit(enemy);
	}

	public void SetPath (Queue<MapTileBehaviour> path) {
		this.path = path;
	}
		
	protected override void updateCurrentLocation (MapTileBehaviour currentTile) {
		if (this.currentTile) {
			this.currentTile.EnemyExitTile(this);
		}
		base.updateCurrentLocation (currentTile);
		Location = currentTile.GetLocation();
		this.currentTile.EnemyEnterTile(this);
	}

	protected override void addSplashDamageTargetsFromTile (MapTileBehaviour tile, List<ActiveObjectBehaviour> targets) {
		if (tile.HasAgent()) {
			targets.Add(tile.GetCurrentAgent());
		}
	}

	public override void Destroy () {
		base.Destroy ();
		EventController.Event(EventType.EnemyDestroyed);
		EventController.Event(EventType.EnemyDestroyed, enemy);
		if (WorldController.Instance) {
			WorldController.Instance.RemoveActiveEnemy(this);
		}
	}

    protected override void HandleNamedEvent(string eventName) {}

		
	protected void resumeMoving () {
		if (this && WorldController.Instance && WorldController.Instance.ICoreOrbInstance != null) {
			NavigatePath();
		}
	}

	public override void NavigatePath (Queue<MapTileBehaviour> path, float timePerStep) {
		base.NavigatePath (path, timePerStep);
		isMoving = true;
	}

	public void NavigatePath () {
		if (path != null) {
			NavigatePath(path, movementSpeed);
		}
	}

	protected override void haltMovementCoroutine () {
		base.haltMovementCoroutine ();
		isMoving = false;
	}

    public override void MoveTo(MapLocation location) {
		if (WorldController.Instance && WorldController.Instance.ICoreOrbInstance != null) {
			SetTarget(WorldController.Instance.ICoreOrbInstance);
		}
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
		haltMovementCoroutine();
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
		if (!collider.isTrigger) {
			checkToAttack(collider);
		}
	}

	void OnTriggerStay (Collider collider) {
		if (!collider.isTrigger) {
			checkToAttack(collider);
		}
	}

	void OnTriggerExit (Collider collider) {
		if (!isMoving && !collider.isTrigger && isTower(collider)) {
			resumeMoving();
		}
	}

	void checkToAttack (Collider collider) {
		if (CanAttack(collider)) {
			TowerBehaviour currentTarget = collider.GetComponent<TowerBehaviour>();
			Attack(currentTarget, enemy.AttackDamage);
			if (previousTarget != currentTarget) {
				Halt();
				currentTarget.SubscribeToDestruction(resumeMoving);
				previousTarget = currentTarget;
			}
		}
	}
		
	bool CanAttack (Collider unit) {
		return !attackCooldownActive && isTower(unit);
	}

	protected bool isTower (Collider collider) {
		return collider.tag.Equals(TowerController.TOWER_TAG);
	}
	protected bool isEnemy (ActiveObjectBehaviour activeObject) {
		return activeObject.gameObject.tag.Equals(EnemyController.ENEMY_TAG);
	}
}
