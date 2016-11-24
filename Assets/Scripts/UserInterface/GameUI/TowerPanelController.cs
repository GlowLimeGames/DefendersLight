/*
 * Author(s): Isaiah Mann
 * Description: Visual display of tower stats
 * Notes: This class should be depracated or incopporated into the larger UIController system
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TowerPanelController : UIController {
	WorldController world;
	const string MANA_FORMAT = "Sell: {0} Mana";
	TowerBehaviour selectedTower;

	[SerializeField]
	Text TowerName;

	[SerializeField]
	Text TowerLevel;

	[SerializeField]
	Button UpgradeButton;

	[SerializeField]
	Button SellButton;

	[SerializeField]
	Text sellValue;

	[SerializeField]
	Image towerImage;

	[SerializeField]
	Image healthBar;

	UIPanelSwipe panelSwipe;
	CanvasGroup canvas;

	bool open = false;

	protected override void FetchReferences () {
		base.FetchReferences ();
		world = WorldController.Instance;
	}

	public void SelectTower (TowerBehaviour tower) {
		if (selectedTower) {
			DeselectTower();
		}
		Tower towerStats = tower.ITower;
		selectedTower = tower;
		TowerName.text = tower.IName;
		TowerLevel.text = tower.LevelString;
		if (!(tower is CoreOrbBehaviour)) {
			SellButton.gameObject.SetActive(true);
			sellValue.text = string.Format(MANA_FORMAT, world.GetTowerSellValue(towerStats));
		} else {
			SellButton.gameObject.SetActive(false);
		}
		tower.SubscribeToDestruction(ClosePanel);
		tower.SubscribeUpdateHealth(updateHealthBar);
		towerImage.sprite = towerStats.GetSprite();
		updateHealthBar(selectedTower.IHealthFraction);
		if (!open) {
			OpenPanel();
		}
	}

	public void DeselectTower () {
		selectedTower.UnusubscribeFromDestruction(ClosePanel);
		selectedTower.UnsubscribeUpdateHealth(updateHealthBar);
		selectedTower = null;
		TowerName.text = string.Empty;
		TowerLevel.text = string.Empty;
		SellButton.gameObject.SetActive(false);
		towerImage.sprite = null;
		updateHealthBar(1.0f);
	}

	void updateHealthBar (float healthFraction) {
		healthBar.fillAmount = healthFraction;
	}

	public void OpenPanel () {
		Show();	
		panelSwipe.RequestOpen();
		open = true;
	}

	public override void Show () {
		base.Show ();
		toggleCanvasGroup(canvas, true);
	}

	public void ClosePanel () {
		if (this != null && gameObject != null) {
			Hide();
			open = false;
		}
	}
		
	public override void Hide () {
		base.Hide ();
		toggleCanvasGroup(canvas, false);
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

	protected override void SetReferences () {
		base.SetReferences ();
		panelSwipe = GetComponent<UIPanelSwipe>();
		canvas = GetComponent<CanvasGroup>();
		panelSwipe.SubscribeToClose(ClosePanel);
	}
}
