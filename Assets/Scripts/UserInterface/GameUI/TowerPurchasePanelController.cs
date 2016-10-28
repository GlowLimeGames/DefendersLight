/*
 * Author(s): Isaiah Mann
 * Description: Controls the tower purchase panel
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TowerPurchasePanelController : UIController {
	CanvasGroup purchaseCanvas;
	TowerPurchasePanel[] towerPuchasePanels;
	[SerializeField]
	UnityEngine.UI.Text title;
	[SerializeField]
	CanvasGroup towerPage;

	public void HandleBeginDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		TogglePurchaseCanvasVisible(false);
		WorldController.Instance.HandleBeginDragPurchase(dragEvent, towerPanel);
	}

	public void HandleDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		WorldController.Instance.HandleDragPurchase(dragEvent, towerPanel);
	}

	public void HandleEndDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		TogglePurchaseCanvasVisible(true);
		WorldController.Instance.HandleEndDragPurchase(dragEvent, towerPanel);
	}

	void TogglePurchaseCanvasVisible (bool isVisible) {
		purchaseCanvas.alpha = isVisible ? 1 : 0;
	}

	protected override void SetReferences () {
		base.SetReferences();
		towerPuchasePanels =  GetComponentsInChildren<TowerPurchasePanel>();
		foreach (TowerPurchasePanel towerPanel in towerPuchasePanels) {
			towerPanel.InitWithController(this);
		}
		purchaseCanvas = GetComponent<CanvasGroup>();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		foreach (TowerPurchasePanel towerPanel in towerPuchasePanels) {
			towerPanel.Setup(input);
		}
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
		int panelIndex = 0;
		for (int i = 0; i <  towers.Length; i++) {
			if (towers[i].Unlocked(DataController.Instance.IPlayer)) {
				towerPuchasePanels[panelIndex].SetTower(towers[i]);
				towerPuchasePanels[panelIndex++].Show();
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
