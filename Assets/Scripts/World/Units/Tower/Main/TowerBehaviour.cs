/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a tower
 */

using UnityEngine;
using System.Collections;

public abstract class TowerBehaviour : StaticAgentBehaviour {

	[SerializeField]
	GameObject MissilePrefab;

	protected override void FetchReferences () {
	}

	protected override void CleanupReferences () {
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
		return null;
	}

	public override void Attack(ActiveObjectBehaviour activeAgent) {
		base.Attack(activeAgent);
		GameObject missile = (GameObject) Instantiate(MissilePrefab, transform.position, Quaternion.identity);

		ProjectileBehaviour missileBehavior = missile.GetComponent<ProjectileBehaviour>();
		missileBehavior.SetTarget(activeAgent);
	}

}
