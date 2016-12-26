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

	[SerializeField]
	Transform secondaryTowerButtonParent;
	[SerializeField]
	GameObject primaryTowerButton;
	[SerializeField]
	GameObject[] secondaryTowerButtons;
	IEnumerator buttonAnimation;
	[SerializeField]
	float timeToShowButtons = 2.0f;
	[SerializeField]
	float timeToHideButtons = 2.0f;
	bool isRunningButtonAnimation = false;
	Vector3 primaryButtonOffset {
		get {
			return primaryTowerButton.transform.position + new Vector3(Screen.width / 12f, -Screen.height / 12f);
		}
	}
	Vector3[] secondaryTowerPositions {
		get {
			Vector3[] positions = new Vector3[secondaryTowerButtons.Length];
			for (int i = 0; i < secondaryTowerButtons.Length; i++) {
				positions[i] = secondaryTowerButtons[i].transform.position;
			}
			return positions;
		}
	}
	bool secondaryButtonsShown = false;

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
			panelSwipe.SubscribeToClose(simpleDeselectPanel);
		}
	}

	void simpleDeselectPanel () {
		TryDeselectSelectedPanel(true, true, false);
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

	void hideButtons () {
		toggleButtons(secondaryButtonsShown:false);
	}

	void showButtons () {
		toggleButtons(secondaryButtonsShown:true);
	}

	void toggleButtons (bool secondaryButtonsShown) {
		TogglePurchaseCanvasVisible(secondaryButtonsShown);
	}

	void stopCurrentButtonAnimation () {
		if (buttonAnimation != null) {
			StopCoroutine(buttonAnimation);
		}
	}
		
	public void ToggleSecondaryButtons () {
		// Don't run if an animation is already running
		if (isRunningButtonAnimation) {
			return;
		}
		if (secondaryButtonsShown) {
			hideButtonAnimation();
		} else {
			showButtonAnimation();
		}
		secondaryButtonsShown = !secondaryButtonsShown;
	}

	void showButtonAnimation () {
		stopCurrentButtonAnimation();
		buttonAnimation = towerButtonAnimation(
			timeToShowButtons, 
			secondaryTowerPositions,
			showButtons,
			primaryButtonOffset);
		StartCoroutine(buttonAnimation);
	}

	void hideButtonAnimation () {
		hideButtons();
		stopCurrentButtonAnimation();
		Vector3 startPosition = primaryButtonOffset;
		buttonAnimation = towerButtonAnimation(
			timeToHideButtons, 
			new Vector3[]{
				startPosition,
				startPosition,
				startPosition
			},
			null,
			secondaryTowerPositions);
		StartCoroutine(buttonAnimation);
	}

	IEnumerator towerButtonAnimation (
		float animationTime, 
		Vector3[] destinations, 
		EventAction callback, 
		params Vector3[] startPositions) {
		GameObject[] buttonStandins = getButtonStandins(startPositions);
		// Repurpose the array to hold the start positions:
		startPositions = new Vector3[buttonStandins.Length];
		for (int i = 0; i < buttonStandins.Length; i++) {
			startPositions[i] = buttonStandins[i].transform.position;
		}
		float timer = 0;
		isRunningButtonAnimation = true;
		while (timer <= animationTime) {
			float progress = Easing.Quadratic.InOut(timer / animationTime);
			for (int i = 0; i < buttonStandins.Length; i++) {
				buttonStandins[i].transform.position = Vector3.Lerp(
					startPositions[i],
					destinations[i],
					progress);
			}
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		for (int i = 0; i < buttonStandins.Length; i++) {
			Destroy(buttonStandins[i]);
		}
		isRunningButtonAnimation = false;
		if (callback != null) callback();
	}

	GameObject[] getButtonStandins (params Vector3[] positions) {
		if (positions.Length == 0) {
			positions = new Vector3[]{Vector3.zero};
		}
		GameObject[] buttonStandins = new GameObject[secondaryTowerButtons.Length];
		int locationIndex = 0;
		int buttonIndex = 0;
		foreach (GameObject button in secondaryTowerButtons) {
			buttonStandins[buttonIndex] = Instantiate(button) as GameObject;
			buttonStandins[buttonIndex].transform.position = positions[locationIndex];
			buttonStandins[buttonIndex].SetActive(true);
			buttonStandins[buttonIndex].transform.SetParent(transform.parent);
			buttonStandins[buttonIndex].transform.localScale = button.transform.localScale;
			buttonIndex++;
			if (locationIndex < positions.Length - 1) {
				locationIndex++;
			}
		}
		return buttonStandins;
	}

	public void OpenTowerPage () {
		ToggleTowerPage(true);
		panelSwipe.RequestOpen();
	}

	public void CloseTowerPage () {
		ToggleTowerPage(false);
	}
}
