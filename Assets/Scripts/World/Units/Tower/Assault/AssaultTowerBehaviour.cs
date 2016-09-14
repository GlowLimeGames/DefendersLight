/*
 * Author(s): Isaiah Mann
 * Description: Behaviour for an assault tower
 */

using UnityEngine;
using System.Collections;

public class AssaultTowerBehaviour : TowerBehaviour {

	protected override void SetReferences() {
		base.SetReferences();
    }

    protected override void FetchReferences() {
		base.FetchReferences();
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
}
