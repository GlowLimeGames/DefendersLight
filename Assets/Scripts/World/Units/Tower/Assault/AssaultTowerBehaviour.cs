﻿/*
 * Author(s): Isaiah Mann
 * Description: Behaviour for an assault tower
 */

using UnityEngine;
using System.Collections;

public class AssaultTowerBehaviour : TowerBehaviour {

	protected override void SetReferences() {
		base.SetReferences();
    }

    protected override void FetchReferences()
    {
		base.FetchReferences();
    }

    protected override void HandleNamedEvent(string eventName)
    {
        throw new System.NotImplementedException();
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

	void OnTriggerEnter (Collider collider) {
		EnemyBehaviour enemy = collider.GetComponent<EnemyBehaviour>();
		if (enemy) {
			Attack(enemy);
		}
	}
}
