using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MobileAgentBehaviour {

    protected override void SetReferences() {
		base.SetReferences();
    }

    protected override void FetchReferences() {
		EnemyController.Instance.Units.Add(this);
    }

	protected override void CleanupReferences () {
		EnemyController.Instance.Units.Remove(this);
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

    public override void MoveTo(BoardLocation location)
    {
        throw new System.NotImplementedException();
    }

	public override ActiveObjectBehaviour SelectTarget() {
		foreach (TowerBehaviour tower in TowerController.Instance.Units) {
			if (InRange(tower)) {
				return tower;
			}
		}

		return null;
	}
}
