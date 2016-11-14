/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerPurchasePanel : UIElement, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler {
	Color cannotPurchaseColor = Color.red;
	Color selectColor = Color.Lerp(Color.blue, Color.white, 0.25f);
	public TowerType TowerType;
	Tower tower;
	CanvasGroup canvasGroup;
	TowerPurchasePanelController controller;
	InputController input;
	DataController data;
	Image image;
	Color standardColor;
	float selectedScale = 1.05f;
	float cannotPurchaseSelectHighlightTime = 0.5f;
	[SerializeField]
	Text purchaseCostText;
	[SerializeField]
	int cost;
	bool cannotPurchaseInteractionOccuring = false;
	bool isSelected;
	IEnumerator showInvalidPurchaseCoroutine;

	public void InitWithController (TowerPurchasePanelController controller) {
		this.controller = controller;
	}

	public void Setup (InputController input, DataController data) {
		this.input = input;
		this.data = data;
	}

	public void SetTower (Tower tower) {
		this.tower = tower;
		SetCost(this.tower.Cost);
		TowerType = tower.TowerType;
		image.sprite = tower.GetSprite();
	}

	public Tower GetTower () {
		return this.tower;
	}
		
	public void SelectPanel () {
		showAsSelected();
		controller.HandlePurchaseSelected(this);
	}

	public bool TryDeselect (bool switchSelection = true) {
		if (isSelected) {
			showAsUnselected();
			stopShowInvalidPurchase();
			cannotPurchaseInteractionOccuring = false;
			if (switchSelection) {
				isSelected = false;
			}
			return true;
		} else {
			return false;
		}
	}

	public void OnPointerClick (PointerEventData pointerEvent) {
		if (!isSelected) {
			if (data.HasSufficientMana(cost)) {
				SelectPanel();
			} else {
				cannotPurchaseInteractionOccuring = true;	
				startShowInvalidPurchase(cannotPurchaseSelectHighlightTime);
				controller.TryDeselectSelectedPanel();
			}
		} else {
			controller.TryDeselectSelectedPanel(shouldSwitchSelected:false);
		}
		isSelected = !isSelected;
	}

	public void OnBeginDrag (PointerEventData pointerEvent) {
		controller.TryDeselectSelectedPanel(false);
		if (data.HasSufficientMana(cost)) {
			HandleCanPurchaseBeginDrag(pointerEvent);
		} else {
			HandleCannotPurchaesBeginDrag();
			input.ToggleDraggingObject(true);
		}
	}

	void HandleCanPurchaseBeginDrag (PointerEventData pointerEvent) {
		controller.HandleBeginDragPurchase(pointerEvent, this);
	}

	void showAsSelected () {
		image.color = selectColor;
		transform.localScale = scalarVector(selectedScale);
	}

	void showAsUnselected () {
		image.color = standardColor;
		if (cannotPurchaseInteractionOccuring) {
			StatsPanelController.Instance.ResetManaTextColor();			
		} else {
			transform.localScale = Vector3.one;
		}
	}
		
	void showAsCannotPurchase () {
		image.color = cannotPurchaseColor;
		StatsPanelController.Instance.SetManaTextColor(cannotPurchaseColor);
	}

	void HandleCannotPurchaesBeginDrag () {
		cannotPurchaseInteractionOccuring = true;
		showAsCannotPurchase();
	}

	public void OnDrag (PointerEventData pointerEvent) {
		if (!cannotPurchaseInteractionOccuring) {
			controller.HandleDragPurchase(pointerEvent, this);
		}
	}

	public void OnEndDrag (PointerEventData pointerEvent) {
		showAsUnselected();
		if (!cannotPurchaseInteractionOccuring) {
			controller.HandleEndDragPurchase(pointerEvent, this);
		} else {
			input.ToggleDraggingObject(false);
		}
		cannotPurchaseInteractionOccuring = false;
	}

	protected override void FetchReferences () {
		base.FetchReferences();
	}

	protected override void SetReferences () {
		base.SetReferences();
		image = GetComponent<Image>();
		standardColor = image.color;
		SetCost(cost);
		canvasGroup = GetComponent<CanvasGroup>();
	}

	void Toggle (bool isActive) {
		this.canvasGroup.alpha = isActive ? 1 : 0;
		this.canvasGroup.blocksRaycasts = isActive;
	}

	public override void Hide () {
		Toggle(false);
	}

	public override void Show () {
		Toggle(true);
	}

	public void SetCost (int cost) {
		this.cost = cost;
		purchaseCostText.text = this.cost.ToString();
	}

	void startShowInvalidPurchase (float forTime) {
		stopShowInvalidPurchase();
		showInvalidPurchaseCoroutine = runShowInvalidPurchase(forTime);
		StartCoroutine(showInvalidPurchaseCoroutine);
	}

	void stopShowInvalidPurchase () {
		if (showInvalidPurchaseCoroutine != null) {
			StopCoroutine(showInvalidPurchaseCoroutine);
		}
	}


	IEnumerator runShowInvalidPurchase (float forTime) {
		showAsCannotPurchase();
		yield return new WaitForSeconds(forTime);
		showAsUnselected();
	}
		
	public void OnPurchased () {
		WorldController.Instance.TrySpendMana(cost);
	}

	protected override void HandleNamedEvent (string eventName) {
		base.HandleNamedEvent(eventName);
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
	}
}
