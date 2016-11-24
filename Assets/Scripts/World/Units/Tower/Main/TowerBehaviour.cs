﻿/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a tower
 */

using UnityEngine;
using System.Collections;

public abstract class TowerBehaviour : StaticAgentBehaviour, ILightSource {
	protected Tower tower;
	[SerializeField]
	SpriteRenderer spriteRenderer;

	[SerializeField]
	GameObject MissilePrefab;

	RangedAttackBehaviour attackModule = null;

	public override float IAttackDelay {
		get {
			return tower.AttackCooldown;
		}
	}
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
			return (float) this.Health / (float) tower.Health;
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

	public virtual void SetTower (Tower tower) {
		this.tower = tower;
		if (spriteRenderer) {
			spriteRenderer.sprite = tower.GetSprite();
		}
		if (attackModule) {
			attackModule.SetUnit(tower);
		}
		setUnit(tower);
	}

	public override string IName {
		get {
			return tower.Type;
		}
	}

	protected override void SetReferences () {
		base.SetReferences ();
		attackModule = GetComponentInChildren<RangedAttackBehaviour>();
	}

	protected override void FetchReferences () {
		if (hasAttack) {
			attackModule = GetComponentInChildren<RangedAttackBehaviour>();
		}
	}

	public override void Destroy () {
		base.Destroy ();
		if (WorldController.Instance) {
			WorldController.Instance.RemoveActiveTower(this);
		}
		EventController.Event(EventType.TowerDestroyed);
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
	}

	public void SelectTower () {
		GameUIController.Instance.SelectTower(this);
	}

	public void DeselectTower () {

	}

	public virtual void PlayBuildSound () {
		EventController.Event(EventType.BuildTower);
	}

	protected override void HandleNamedEvent (string eventName) {

	}

	public void Sell () {
		(unitController as TowerController).SellTower(this.tower);
		unitController.HandleObjectDestroyed(this);
		tile.RemoveAgent();
		EventController.Event(EventType.TowerSold);
	}

	public override void Attack(ActiveObjectBehaviour activeAgent, int damage) {
		// Tower cannot attack if its square is not illuminated:
		if (!tile.IIsIlluminated) {
			return;
		}

		StartCoroutine(AttackCooldown());
		ProjectileBehaviour missileBehavior;
		if (ProjectilePool.Instance && !ProjectilePool.Instance.IsEmpty) {
			missileBehavior = ProjectilePool.Instance.Take();
			missileBehavior.transform.position = transform.position;
		} else {
			missileBehavior = ((GameObject) Instantiate(MissilePrefab, transform.position, Quaternion.identity)).GetComponent<ProjectileBehaviour>();
		}
		missileBehavior.SetTower(tower);
		missileBehavior.SetTarget(activeAgent);
		// StartCoroutine(trackMissile(missileBehavior.transform, 1f));
	}

	IEnumerator trackMissile (Transform missileTransform, float time) {
		float timer = 0;
		while (timer <= time) {
			spriteRenderer.transform.LookAt(missileTransform, Vector3.up);
			spriteRenderer.transform.eulerAngles = new Vector3(90, spriteRenderer.transform.eulerAngles.y, spriteRenderer.transform.eulerAngles.z);
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

	int mostRecentIlluminationCount = NONE_VALUE;
	int mostRecentIlluminationRadius = NONE_VALUE;


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
