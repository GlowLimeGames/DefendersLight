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
	UIPanelSwipe panelSwipe;
	TowerType currentTowerType;
	TowerPurchasePanel mostRecentClickedPanel;
	float mostRecentTimePanelClicked = float.MinValue;
	[SerializeField]
	float clickThresholdForTowerLock = 1;
	[SerializeField]
	bool towerLockEnabled = true; // Should this be an actual setting?
	public bool TowerSelectLock {
		get {
			return _towerSelectLock;
		}
	}

	/* 
	 * A state in which the user may click on an arbitrary number of squares to build the currently selected tower
	 * Default behaviour is that a tower panel becomes unselected on click to place
	 */
	bool _towerSelectLock = false;

	public bool CheckForTowerSelectLock (TowerPurchasePanel panel, bool onClick = false) {
		if (towerLockEnabled) {
			_towerSelectLock = mostRecentClickedPanel == panel &&  ((_towerSelectLock && !onClick) || (onClick && withinTowerSelectLockTimeThreshold() && panel.IsSelected));
			mostRecentClickedPanel = panel;
			mostRecentTimePanelClicked = Time.time;
			return _towerSelectLock;
		} else {
			return false;
		}
	}
		
	bool withinTowerSelectLockTimeThreshold () {
		return Time.time - mostRecentTimePanelClicked < clickThresholdForTowerLock;
	}

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
		TryDeselectSelectedPanel(shouldSwitchSelected:true, towerPanelChange:true);
		this.selectedPurchasePanel = towerPanel;
		world.HandleTowerPurchaseSelected(towerPanel.GetTower());
	}

	public bool TryDeselectSelectedPanel (bool shouldSwitchSelected = true, bool towerPanelChange = false, bool onClick = false) {
		if (this.selectedPurchasePanel) {
			map.UnhighlightValidBuildsTiles();
			this.selectedPurchasePanel.TryDeselect(shouldSwitchSelected, towerPanelChange, onClick);
			this.selectedPurchasePanel = null;
			if (towerPanelChange) {
				_towerSelectLock = false;
			}
			EventController.Event(EventType.TowerPanelDeselected);
			return true;
		} else {
			return false;
		}
	}

	void TogglePurchaseCanvasVisible (bool isVisible) {
		purchaseCanvas.alpha = isVisible ? 1 : 0;
	}

	void refreshTowerPanel () {
		SetTowers(currentTowerType);
	}

	protected override void HandleNamedEvent (string eventName) {
		if (eventName == EventType.RefreshTowerPanel) {
			refreshTowerPanel();
		} else if (eventName == EventType.TowerUnlocked) {
			// Trigger the refresh event if we see the unlock 
			EventController.Event(EventType.RefreshTowerPanel);
		} else {
			base.HandleNamedEvent (eventName);
		}
	}

	protected override void SetReferences () {
		if (SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			base.SetReferences();
			towerPuchasePanels =  GetComponentsInChildren<TowerPurchasePanel>();
			foreach (TowerPurchasePanel towerPanel in towerPuchasePanels) {
				towerPanel.InitWithController(this);
			}
			purchaseCanvas = GetComponent<CanvasGroup>();
			panelSwipe.SubscribeToClose(CloseTowerPage);
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
		this.currentTowerType = type;
	}

	public void SetTowers (Tower[] towers) {
		if (TryDeselectSelectedPanel(shouldSwitchSelected:true, towerPanelChange:true)) {
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
		panelSwipe.RequestOpen();
	}

	public void CloseTowerPage () {
		ToggleTowerPage(false);
	}
}
