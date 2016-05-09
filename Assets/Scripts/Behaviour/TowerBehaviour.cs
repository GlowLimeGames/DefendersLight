using UnityEngine;
using System.Collections;

public abstract class TowerBehaviour : StaticAgentBehaviour {

	protected override void FetchReferences () {
		TowerController.Instance.Units.Add(this);
	}

	protected override void CleanupReferences () {
		TowerController.Instance.Units.Remove(this);
	}

	void OnMouseDown () {
		SelectTower();
	}
		
	public void SelectTower () {
		UIController.Instance.SelectTower(this);
	}

	public void DeselectTower () {

	}

	public override ActiveObjectBehaviour SelectTarget() {
		foreach (EnemyBehaviour enemy in EnemyController.Instance.Units) {
			if (InRange(enemy)) {
				return enemy;
			}
		}

		return null;
	}

	public override void Attack(ActiveObjectBehaviour activeAgent) {
		base.Attack(activeAgent);
	}

}
