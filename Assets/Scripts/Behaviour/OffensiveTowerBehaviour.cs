using UnityEngine;
using System.Collections;

public class OffensiveTowerBehaviour : TowerBehaviour {

    protected override void SetReferences()
    {
        throw new System.NotImplementedException();
    }

    protected override void FetchReferences()
    {
        throw new System.NotImplementedException();
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
