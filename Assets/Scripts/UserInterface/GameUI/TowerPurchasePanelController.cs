/*
 * Author(s): Isaiah Mann
 * Description: Controls the tower purchase panel
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TowerPurchasePanelController : UIController {
	public static TowerPurchasePanelController Instance;
	CanvasGroup purchaseCanvas;
	TowerPurchasePanel[] towerPuchasePanels;
	TowerPurchasePanel selectedPurchasePanel;
	[SerializeField]
	UnityEngine.UI.Text title;
	[SerializeField]
	CanvasGroup towerPage;
	WorldController world;
	MapController map;
	[SerializeField]
	UISwipeToClose close;

	public void HandleBeginDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		TogglePurchaseCanvasVisible(false);
		world.HandleBeginDragPurchase(dragEvent, towerPanel);
	}

	public void HandleDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		world.HandleDragPurchase(dragEvent, towerPanel);
	}

	public void HandleEndDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		TogglePurchaseCanvasVisible(true);
		world.HandleEndDragPurchase(dragEvent, towerPanel);
	}

	public void HandlePurchaseSelected (TowerPurchasePanel towerPanel) {
		TryDeselectSelectedPanel();
		this.selectedPurchasePanel = towerPanel;
		world.HandleTowerPurchaseSelected(towerPanel.GetTower());
	}

	public bool TryDeselectSelectedPanel (bool shouldSwitchSelected = true) {
		if (this.selectedPurchasePanel) {
			map.UnhighlightValidBuildsTiles();
			this.selectedPurchasePanel.TryDeselect(shouldSwitchSelected);
			this.selectedPurchasePanel = null;
			return true;
		} else {
			return false;
		}
	}

	void TogglePurchaseCanvasVisible (bool isVisible) {
		purchaseCanvas.alpha = isVisible ? 1 : 0;
	}

	protected override void SetReferences () {
		if (SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			base.SetReferences();
			towerPuchasePanels =  GetComponentsInChildren<TowerPurchasePanel>();
			foreach (TowerPurchasePanel towerPanel in towerPuchasePanels) {
				towerPanel.InitWithController(this);
			}
			purchaseCanvas = GetComponent<CanvasGroup>();
			close.SubscribeToClose(CloseTowerPage);
		}
	}

	protected override void FetchReferences () {
		if (SingletonUtil.IsSingleton(Instance, this)) {
			base.FetchReferences ();
			world = WorldController.Instance;
			map = MapController.Instance;
			foreach (TowerPurchasePanel towerPanel in towerPuchasePanels) {
				towerPanel.Setup(input, data);
			}
		}
	}

	protected override void CleanupReferences () {
		base.CleanupReferences ();
		SingletonUtil.TryCleanupSingleton(ref Instance, this);
	}

	Tower[] GetTowers (TowerType type) {
		return WorldController.Instance.GetTowersOfType(type);
	}

	public void SetToIllumination () {
		SetTowers(TowerType.Illumination);
	}

	public void SetToAssault () {
		SetTowers(TowerType.Assault);
	}

	public void SetToBarricade () {
		SetTowers(TowerType.Barricade);
	}

	public void SetTowers (TowerType type) {
		SetTowers(GetTowers(type));
		if (title) {
			title.text = type.ToString();
		}
	}

	public void SetTowers (Tower[] towers) {
		if (TryDeselectSelectedPanel()) {
			map.UnhighlightValidBuildsTiles();
		}
		int panelIndex = 0;
		for (int i = 0; i <  towers.Length; i++) {
			if (world.OverrideTowerLevelRequirement || towers[i].Unlocked(DataController.Instance.IPlayer)) {
				towerPuchasePanels[panelIndex].SetTower(towers[i]);
				towerPuchasePanels[panelIndex].Show();
				panelIndex++;
			}
		}
		for (int j = panelIndex; j < towerPuchasePanels.Length; j++) {
			towerPuchasePanels[j].Hide();
		}
	}
		
	void ToggleTowerPage (bool isActive) {
		towerPage.alpha = isActive ? 1 : 0;
		towerPage.blocksRaycasts = isActive;
		towerPage.interactable = isActive;
	}

	public void OpenTowerPage () {
		ToggleTowerPage(true);
	}

	public void CloseTowerPage () {
		ToggleTowerPage(false);
	}
}
