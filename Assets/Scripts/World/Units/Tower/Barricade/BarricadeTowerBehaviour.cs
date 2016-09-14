/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of barricade towers. Immovable, defensive structures, typically no purpose beyond absorbing damage and blcoking the enemy
 */

using UnityEngine;
using System.Collections;

public class BarricadeTowerBehaviour : TowerBehaviour {

	protected override void SetReferences() {
		base.SetReferences();
		HasAttack = false;
    }

    protected override void FetchReferences() {
    }

    protected override void HandleNamedEvent(string eventName) {
        
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
