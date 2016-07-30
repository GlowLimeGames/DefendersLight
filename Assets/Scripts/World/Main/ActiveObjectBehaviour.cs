/*
 * Author(s): Isaiah Mann
 * Description: Template behaviour for active word objects (can interact w/ other objects in the world and affect the game logic)
 */

using UnityEngine;
using System.Collections;

public abstract class ActiveObjectBehaviour : WorldObjectBehaviour {
	[SerializeField]
	GenericStats _stats;

	[SerializeField]
	protected bool HasAttack;

	[SerializeField]
	protected HealthBarBehaviour HealthBar;

	bool _attackCooldownActive = false;

	[SerializeField]
	bool debugging;

	void Update () {
		CheckForAttack();
	}

	void SetStats () {
		if (_stats != null) {
			// Code adapted from: http://answers.unity3d.com/questions/39130/cloning-of-scriptableobject.html
			_stats = Object.Instantiate(_stats) as GenericStats;
		}
	}

	protected override void SetReferences () {
		SetStats();
	}

	protected virtual void CheckForAttack () {
		if (HasAttack && !_attackCooldownActive) {
			ActiveObjectBehaviour target = SelectTarget();

			if (target != null) {
				Attack(target);
			}
		}
	}

	public virtual void Attack(ActiveObjectBehaviour activeAgent) {
		StartCoroutine(AttackCooldown());
		activeAgent.Damage(_stats.Damage);
	}

	public abstract ActiveObjectBehaviour SelectTarget();

	public virtual void Damage(int damage) {
		_stats.Health -= damage;
		HealthBar.SetHealthDisplay(
			(float) _stats.Health /
			(float) _stats.MaxHealth
		);

		if (_stats.Health <= 0) {
			Destroy();
		}
	}
    
	public virtual void Heal(int healthPoints) {
		_stats.Health += healthPoints;
	}
    
	public virtual void Destroy() {
		DestroyObject(gameObject);
	}

	public virtual bool InRange(ActiveObjectBehaviour activeAgent) {
		return (_stats.Range >= MapLocation.Distance(Location, activeAgent.Location));
	}

	public GenericStats GetStats () {
		return _stats;
	}

	IEnumerator AttackCooldown () {
		_attackCooldownActive = true;
		yield return new WaitForSeconds(_stats.AttackDelay);
		_attackCooldownActive = false;
	}
}
