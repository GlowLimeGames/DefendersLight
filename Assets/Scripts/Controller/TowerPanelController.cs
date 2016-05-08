using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TowerPanelController : MannBehaviour {

	TowerBehaviour selectedTower;

	[SerializeField]
	Text TowerName;

	[SerializeField]
	Text TowerLevel;

	[SerializeField]
	Button UpgradeButton;

	[SerializeField]
	Button SellButton;

	public void SelectTower (TowerBehaviour tower) {
		selectedTower = tower;
		gameObject.SetActive(true);

		GenericStats stats = tower.GetStats();

		TowerName.text = stats.Name;
		TowerLevel.text = stats.LevelString;
	}

	public void ClosePanel () {
		gameObject.SetActive(false);
	}
		
	protected override void FetchReferences () {

	}

	protected override void SetReferences () {

	}

	protected override void HandleNamedEvent (string eventName) {

	}

}
