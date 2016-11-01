/*
 * Author(s): Isaiah Mann
 * Description: Template behaviour for active word objects (can interact w/ other objects in the world and affect the game logic)
 */

using UnityEngine;
using System.Collections;

public abstract class ActiveObjectBehaviour : WorldObjectBehaviour {
	public string Name;
	public int Health;
	public int BaseDamage;
	public int Range;
	public string LevelString;
	public float AttackDelay;
	int _maxHealth = 0;
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
	Unit unit;

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

	protected override void SetReferences () {
		SetStats();
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
		if (onDestroyed != null) {	
			onDestroyed();
		}
	}
		
	public virtual void Attack(ActiveObjectBehaviour activeAgent, int damage) {
		StartCoroutine(AttackCooldown());
		activeAgent.Damage(damage);
	}

	public virtual void Damage(int damage) {
        if (!isInvulnerable) {
            Health -= damage;
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
    
	void updateHealthBar () {
		if (HealthBar) {
			HealthBar.SetHealthDisplay(
				(float) Health /
				(float) this.unit.Health
			);
		}
	}

	public virtual void HealTarget (ActiveObjectBehaviour target, int healthPoints) {
		target.Heal(healthPoints);
	}

	protected virtual bool canHealTarget (ActiveObjectBehaviour target) {
		return canHeal;
	}

	public virtual void Destroy() {
		DestroyObject(gameObject);
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

	public void ToggleColliders (bool areCollidersEnabled) {
		foreach (Collider collider in GetComponents<Collider>()) {
			collider.enabled = areCollidersEnabled;
		}
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
	}

	public virtual void ToggleActive (bool isActive) {
		this.isActive = isActive;
	}
}
