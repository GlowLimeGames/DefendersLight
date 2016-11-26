/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a tower
 */

using UnityEngine;
using System.Collections;

public abstract class TowerBehaviour : StaticAgentBehaviour, ILightSource {
	protected TowerController controller;
	protected Tower tower;
	[SerializeField]
	SpriteRenderer spriteRenderer;

	[SerializeField]
	GameObject MissilePrefab;

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
		setUnit(tower);
	}

	public override string IName {
		get {
			return tower.Type;
		}
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

	int mostRecentIlluminationCount = NONE_VALUE;
	int mostRecentIlluminationRadius = NONE_VALUE;

	protected override void FetchReferences () {
		base.FetchReferences();
		this.controller = TowerController.Instance;
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

	public virtual void CallBuildEvent () {
		EventController.Event(EventType.TowerBuilt);
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
		base.Attack(target, damage);
	}
 
//	protected override ProjectileBehaviour handleRangedAttack (ActiveObjectBehaviour target, int damage) {
//		ProjectileBehaviour missile = base.handleRangedAttack (target, damage);
//		missile.SetTower(tower);
//		missile.SetTarget(target);
//		return missile;
//	}

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
