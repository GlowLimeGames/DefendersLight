/*
 * Author(s): Isaiah Mann
 * Description: Controls the tower purchase panel
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TowerPurchasePanelController : UIController {
	CanvasGroup purchaseCanvas;

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
		foreach (TowerPurchasePanel towerPanel in GetComponentsInChildren<TowerPurchasePanel>()) {
			towerPanel.InitWithController(this);
		}
		purchaseCanvas = GetComponent<CanvasGroup>();
	}
}
