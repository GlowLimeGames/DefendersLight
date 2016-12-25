/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a tower
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class TowerBehaviour : StaticAgentBehaviour, ILightSource {
	float DEFAULT_TOWER_ATTACK_DELAY = 0.5f;
	protected TowerController controller;
	protected Tower tower;
	[SerializeField]
	SpriteRenderer spriteRenderer;

	[SerializeField]
	GameObject MissilePrefab;
	protected bool isTrackingTarget;
	public override int IMaxHealth {
		get {
			return tower.Health;
		}
	}
	public Tower ITower {
		get {
			return this.tower;
		}
	}
	public float IHealthFraction {
		get {
			return (float) this.health / (float) tower.Health;
		}
	}
	public bool HasIllumination {
		get {
			if (tower == null) {
				return false;
			} else {
				return tower.HasIllumination;
			}
		}
	}
	public bool IsReflective {
		get {
			return tower.IsReflective;
		}
	}
	public virtual void SetTower (Tower tower) {
		this.tower = tower;
		if (spriteRenderer) {
			spriteRenderer.sprite = tower.GetSprite();
		}
		setUnit(tower);
	}

	public int IlluminationRadius {
		get {
			// The core orb can be illuminated even if there is nothing else illuminating it
			if (tower == null || (!(tile.IIsIlluminated || this is CoreOrbBehaviour))) {
				return NONE_VALUE;
			} else {
				if (tower.IlluminationRadiusIsVariable) {
					return CalculateVariableIlluminationRadius();
				} else {
					return tower.IIlluminationRadius;
				}
			}
		}
	}

	public MapTileBehaviour ITile {
		get {
			return this.tile;
		}
	}

	protected override void addSplashDamageTargetsFromTile (MapTileBehaviour tile, List<ActiveObjectBehaviour> targets) {
		if (tile.HasEnemies()) {
			targets.AddRange(tile.GetEnemiesOnTile());
		}
	}
		
	int mostRecentIlluminationCount = NONE_VALUE;
	int mostRecentIlluminationRadius = NONE_VALUE;

	protected override void SetReferences () {
		base.SetReferences ();
		attackDelay = DEFAULT_TOWER_ATTACK_DELAY;
	}

	protected override void FetchReferences () {
		base.FetchReferences();
		this.controller = TowerController.Instance;
	}

	public override void Destroy () {
		base.Destroy ();
		if (WorldController.Instance) {
			WorldController.Instance.RemoveActiveTower(this);
		}
		CallDestroyEvent();
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
	}

	public void SelectTower () {
		GameUIController.Instance.SelectTower(this);
	}

	public void DeselectTower () {

	}

	public virtual void CallBuildEvent () {
		EventController.Event(EventType.TowerBuilt);
	}

	public virtual void CallDestroyEvent () {
		EventController.Event(EventType.TowerDestroyed);
	}

	protected override void HandleNamedEvent (string eventName) {

	}

	public void Sell () {
		(unitController as TowerController).SellTower(this.tower);
		unitController.HandleObjectDestroyed(this);
		tile.RemoveAgent();
		EventController.Event(EventType.TowerSold);
	}

	public override void Attack(ActiveObjectBehaviour target, int damage) {
		// Tower cannot attack if its square is not illuminated:
		if (!tile.IIsIlluminated) {
			return;
		}
		// Base method updates whether we should be tracking the enemy so should be called first
		base.Attack(target, damage);
		if (tower.IRotateToTarget && !isTrackingTarget) {
			StartCoroutine(trackTarget(target.transform));
		}
	}
 
	IEnumerator trackTarget (Transform targetTransform, bool smoothTransition = true) {
		isTrackingTarget = true;
		if (smoothTransition) {
			Quaternion startingRotation = transform.rotation;
			float timer = 0;
			while (HasTarget && timer <= attackDelay) {
				transform.rotation = Quaternion.Lerp(startingRotation, 
					Quaternion.LookRotation(targetTransform.position - transform.position), 
					timer / attackDelay);
				setHealthBarRotation();
				yield return new WaitForEndOfFrame();
				timer += Time.deltaTime;
			}
		}
		while (HasTarget) {
			transform.LookAt(targetTransform);
			setHealthBarRotation();
			yield return new WaitForEndOfFrame();
		}
		isTrackingTarget = false;
	}
		
	IEnumerator trackMissile (Transform missileTransform, float time) {
		float timer = 0;
		while (timer <= time) {
			transform.LookAt(missileTransform, Vector3.up);
			setHealthBarRotation();
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}

	public override void HandleColliderEnterTrigger (Collider collider) {
		base.HandleColliderEnterTrigger (collider);
		if (isActive) {
			checkToAttack(collider);
		}
	}

	public override void HandleColliderStayTrigger (Collider collider)	{
		base.HandleColliderStayTrigger (collider);
		checkToAttack(collider);
	}

	public int UpdateIlluminationRadius () {
		if (tile) {
			mostRecentIlluminationCount = tile.IllumninationCount;
		} else {
			mostRecentIlluminationCount = NONE_VALUE;
		}
		mostRecentIlluminationRadius = IlluminationRadius;
		return mostRecentIlluminationRadius;
	}
		
	public bool ShouldReculateIllumination () {
		if (tile) {
			return mostRecentIlluminationCount != tile.IllumninationCount && mostRecentIlluminationRadius != IlluminationRadius;
		} else {
			return false;
		}
	}

	public int CalculateVariableIlluminationRadius () {
		if (tower.IsReflective) {
			return Mathf.CeilToInt((float)tile.IllumninationCount * tower.IReflectivitiy);
		} else {
			return NONE_VALUE;
		}
	}

	void checkToAttack (Collider collider) {
		if (hasAttack && !attackCooldownActive) {
			if (collider.tag == EnemyController.ENEMY_TAG) {
				EnemyBehaviour enemy = collider.GetComponent<EnemyBehaviour>();
				if (enemy.CanDamage(this)) {
					Attack(enemy, tower.AttackDamage);
				}
			}
		}
	}
}
