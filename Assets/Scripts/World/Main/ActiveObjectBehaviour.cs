/*
 * Author(s): Isaiah Mann
 * Description: Template behaviour for active word objects (can interact w/ other objects in the world and affect the game logic)
 */

using UnityEngine;
using System.Collections;

public abstract class ActiveObjectBehaviour : WorldObjectBehaviour {
	protected float attackDelay = 0;
	EventActionf onUpdateHealth;
	protected UnitController unitController;
	// A child object that represents the enemies range (using a separate collider)
	RangedAttackBehaviour attackModule = null;
	public string Name;
	public int Health;
	public int BaseDamage;
	public int Range;
	public string LevelString;
	public float AttackDelay;
	int _maxHealth = 0;
	// Makes sure that we don't keep calling events related to a destroyed unit
	bool hasBeenDestroyed = false;
    public bool isInvulnerable = false;
	public AttackType AttackType;
	public virtual float IAttackDelay {
		get {
			return AttackDelay;
		}
	}
	public virtual string IName {
		get {
			return Name;
		}
	}
	public virtual int IMaxHealth {
		get {
			return _maxHealth;
		}
	}
	public bool IAtFullHealth {
		get {
			return Health == IMaxHealth;
		}
	}
	public virtual string IType {
		get {
			return unit.Type;
		}
	}
	public string IAmmo {
		get {
			return unit.IAmmo;
		}
	}
	protected Unit unit;
	protected ActiveObjectBehaviour target;
	public bool HasTarget {
		get {
			// MonoBehaviours autocast to bools for whether they exist in the world (returns false if null)
			return target;
		}
	}
	EventAction onDestroyed;
	[SerializeField]
	protected bool hasAttack;
	[SerializeField]
	protected bool canHeal = false;

	[SerializeField]
	protected HealthBarBehaviour HealthBar;

	protected bool attackCooldownActive = false;
	protected bool isActive = true;
	public bool IIsActive {
		get {
			return isActive;
		}
	}
	[SerializeField]
	bool debugging;

	IUnit linkedObject;
	public IUnit ILinkedObject {
		get {
			return linkedObject;
		}
	}
		
	void SetStats () {
	}

	public void SubscribeUpdateHealth (EventActionf eventAction) {
		onUpdateHealth += eventAction;
	}

	public void UnsubscribeUpdateHealth (EventActionf eventAction) {
		onUpdateHealth -= eventAction;
	}

	protected override void SetReferences () {
		base.SetReferences ();
		if (hasAttack) {
			attackModule = GetComponentInChildren<RangedAttackBehaviour>();
		}
	}

	public virtual void Setup (UnitController unitController) {
		this.unitController = unitController;
	}

	protected void clearTarget () {
		this.target = null;
	}

	public virtual void Attack(ActiveObjectBehaviour target, int damage) {
		this.target = target;
		// Ensures that the same event is not subscribed multiple times
		target.UnusubscribeFromDestruction(clearTarget);
		target.SubscribeToDestruction(clearTarget);
		StartCoroutine(AttackCooldown());
		if (AttackType == AttackType.Melee) {
			StartCoroutine(handleMeleeAttack(target, damage));
		} 
		// Energy attacks are treated as ranged, however they're specialized because they can damage Shades (only towers with this ability)
		else if (AttackType == AttackType.Energy || AttackType == AttackType.Projectile) {
			StartCoroutine(handleRangedAttack(target, damage));
		}
	}
		
	protected virtual IEnumerator handleMeleeAttack (ActiveObjectBehaviour target, int damage) {
		yield return new WaitForSeconds(attackDelay);
		meleeAttack(target, damage);
	}

	protected virtual void meleeAttack (ActiveObjectBehaviour target, int damage) {
		target.Damage(damage);
	}

	protected virtual IEnumerator handleRangedAttack (ActiveObjectBehaviour target, int damage) {
		yield return new WaitForSeconds(attackDelay);
		rangedAttack(target, damage);
	}

	protected virtual ProjectileBehaviour rangedAttack (ActiveObjectBehaviour target, int damage) {
		ProjectileBehaviour missileBehavior;
		// Need a superclass ref to reuse the method inside WorldController for the spawn poolsb
		ActiveObjectBehaviour missileStandIn;
		if (world && world.TryPullFromSpawnPool(IAmmo, out missileStandIn)) {
			missileBehavior = missileStandIn as ProjectileBehaviour;
			missileBehavior.transform.position = transform.position;
		} else {
			missileBehavior = Instantiate(unitController.loadProjectilePrefab(IAmmo), transform.position, Quaternion.identity) as ProjectileBehaviour;
		}
		missileBehavior.setUnit(this.unit);
		missileBehavior.SetTarget(target);
		return missileBehavior;
	}
		
	public virtual void Damage(int damage) {
		if (hasBeenDestroyed) {
			return;
		}

		if (!isInvulnerable) {
            Health -= damage;
			callUpdateHealth((float) Health / (float) IMaxHealth);
        }
		if (Health <= 0) {
			Destroy();
		} else {
			updateHealthBar();
		}
	}
    
	public virtual void Heal(int healthPoints) {
		Health = Mathf.Clamp(Health + healthPoints, 0, IMaxHealth);
		updateHealthBar();
	}
    
	public virtual void OnSpawn () {
		ResetStats();
	}

	public virtual void ResetStats () {
		Health = IMaxHealth;
		hasBeenDestroyed = false;
		updateHealthBar();
	}

	void updateHealthBar () {
		if (HealthBar) {
			HealthBar.SetHealthDisplay(
				(float) Health /
				(float) IMaxHealth
			);
		}
	}

	void callUpdateHealth (float healthFraction) {
		if (onUpdateHealth != null) {
			onUpdateHealth(healthFraction);
		}
	}

	public virtual void HealTarget (ActiveObjectBehaviour target, int healthPoints) {
		target.Heal(healthPoints);
	}

	protected virtual bool canHealTarget (ActiveObjectBehaviour target) {
		return canHeal;
	}

	public virtual void Destroy() {
		unitController.HandleObjectDestroyed(this);	
		hasBeenDestroyed = true;
		ToggleColliders(false);
		if (onDestroyed != null) {	
			onDestroyed();
		}
	}

	public virtual bool InRange(ActiveObjectBehaviour activeAgent) {
		return (Range >= MapLocation.Distance(Location, activeAgent.Location));
	}

	public void ReceiveLink (IUnit unit) {
		linkedObject = unit;
	}

	public void SeverLink () {
		linkedObject = null;
	}

	public bool HasLink () {
		return linkedObject != null;
	}

	protected IEnumerator AttackCooldown () {
		attackCooldownActive = true;
		yield return new WaitForSeconds(unit.AttackCooldown);
		attackCooldownActive = false;
	}

	public void SubscribeToDestruction (EventAction action) {
		onDestroyed += action;
	}

	public void UnusubscribeFromDestruction (EventAction action) {
		onDestroyed -= action;
	}
		
	public virtual bool CanDamage (ActiveObjectBehaviour attacker) {
		return true;
	}

	public virtual void HandleColliderEnterTrigger (Collider collider) {}

	public virtual void HandleColliderStayTrigger (Collider collider) {}

	public virtual void HandleColliderExitTrigger (Collider collider) {}

	protected void setUnit (Unit unit) {
		this.unit = unit;
		this.Health = unit.Health;
		if (attackModule) {
			attackModule.SetUnit(unit);
		}
	}

	public virtual void ToggleActive (bool isActive) {
		this.isActive = isActive;
	}
}
