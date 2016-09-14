/*
 * Author(s): Isaiah Mann
 * Description: Behaviour of an illumination tower
 */

using UnityEngine;
using System.Collections;

public class IlluminationTowerBehaviour : TowerBehaviour {
    
	protected override void SetReferences() {
		base.SetReferences();
		HasAttack = false;
    }

	protected override void FetchReferences () {
		base.FetchReferences();
	}
    protected override void HandleNamedEvent(string eventName) {
		
    }
    
	public int IlluminationRadius;

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
