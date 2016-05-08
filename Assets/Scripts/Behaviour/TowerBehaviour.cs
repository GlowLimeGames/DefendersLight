using UnityEngine;
using System.Collections;

public abstract class TowerBehaviour : StaticAgentBehaviour {
    [SerializeField]
    GenericStats _stats;

	void OnMouseDown () {
		SelectTower();
	}

	public void SelectTower () {
		UIController.Instance.SelectTower(this);
	}

	public void DeselectTower () {

	}

	public GenericStats GetStats () {
		return _stats;
	}
}
