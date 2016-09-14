/*
 * Author(s): Isaiah Mann
 * Description: Template behaviour for active word objects (can interact w/ other objects in the world and affect the game logic)
 */

using UnityEngine;
using System.Collections;

public abstract class ActiveObjectBehaviour : WorldObjectBehaviour {
	public string Name;
	public int Health;
	public int MaxHealth;
	public int BaseDamage;
	public int Range;
	public string LevelString;
	public float AttackDelay;

	[SerializeField]
	protected bool HasAttack;

	[SerializeField]
	protected HealthBarBehaviour HealthBar;

	protected bool attackCooldownActive = false;

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

	protected virtual void CheckForAttack () {
		if (HasAttack && !attackCooldownActive) {
			ActiveObjectBehaviour target = SelectTarget();

			if (target != null) {
				Attack(target);
			}
		}
	}

	public virtual void Attack(ActiveObjectBehaviour activeAgent) {
		StartCoroutine(AttackCooldown());
		activeAgent.Damage(BaseDamage);
	}

	public abstract ActiveObjectBehaviour SelectTarget();

	public virtual void Damage(int damage) {
		Health -= damage;
		if (HealthBar) {
			HealthBar.SetHealthDisplay(
				(float) Health /
				(float) MaxHealth
			);
		}
		if (Health <= 0) {
			Destroy();
		}
	}
    
	public virtual void Heal(int healthPoints) {
		Health += healthPoints;
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
		yield return new WaitForSeconds(AttackDelay);
		attackCooldownActive = false;
	}

	public void ToggleColliders (bool areCollidersEnabled) {
		foreach (Collider collider in GetComponents<Collider>()) {
			collider.enabled = areCollidersEnabled;
		}
	}
}
