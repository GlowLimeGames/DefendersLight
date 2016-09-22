/*
 * Author(s): Isaiah Mann
 * Description: Visual display of tower stats
 * Notes: This class should be depracated or incopporated into the larger UIController system
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TowerPanelController : UIController {

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
		TowerName.text = tower.Name;
		TowerLevel.text = tower.LevelString;
		SellButton.gameObject.SetActive(!(tower is CoreOrbBehaviour));
	}

	public void ClosePanel () {
		gameObject.SetActive(false);
	}
		
	public void SellTower () {
		if (selectedTower) {
			selectedTower.Sell();
			ClosePanel();
		}
	}

	public TowerBehaviour GetSelectedTower () {
		return selectedTower;
	}
}
