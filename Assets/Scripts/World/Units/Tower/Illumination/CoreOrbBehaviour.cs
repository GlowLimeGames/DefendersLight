/*
 * Author(s): Isaiah Mann
 * Description: The behaviour of the core orb in game
 * Notes: Within the current design, only one core orb should ever exist
 */

using UnityEngine;
using System.Collections;

public class CoreOrbBehaviour : IlluminationTowerBehaviour {
    
	protected override void SetReferences() {

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
}
