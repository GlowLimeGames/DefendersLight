/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerPurchasePanel : MannBehaviour, IUIInteractiveElement, IBeginDragHandler, IDragHandler, IEndDragHandler {
	public TowerType TowerType;
	Tower tower;
	CanvasGroup canvasGroup;
	TowerPurchasePanelController controller;
	InputController input;
	Image image;
	Color standardColor;
	float selectedScale = 1.05f;
	[SerializeField]
	Text purchaseCostText;
	[SerializeField]
	int cost;
	bool cannotPurchaseDragOccuring = false;

	public void InitWithController (TowerPurchasePanelController controller) {
		this.controller = controller;
	}

	public void Setup (InputController input) {
		this.input = input;
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

	public void OnBeginDrag (PointerEventData pointerEvent) {
		if (DataController.Instance.HasSufficientMiniOrbs(cost)) {
			HandleCanPurchaseBeginDrag(pointerEvent);
		} else {
			HandleCannotPurchaesBeginDrag();
			input.ToggleDraggingObject(true);
		}
	}

	void HandleCanPurchaseBeginDrag (PointerEventData pointerEvent) {
		controller.HandleBeginDragPurchase(pointerEvent, this);
		image.color = Color.gray;
		transform.localScale *= selectedScale;
	}

	void HandleCannotPurchaesBeginDrag () {
		image.color = Color.red;
		cannotPurchaseDragOccuring = true;
	}

	public void OnDrag (PointerEventData pointerEvent) {
		if (!cannotPurchaseDragOccuring) {
			controller.HandleDragPurchase(pointerEvent, this);
		}
	}

	public void OnEndDrag (PointerEventData pointerEvent) {
		if (!cannotPurchaseDragOccuring) {
			controller.HandleEndDragPurchase(pointerEvent, this);
			transform.localScale /= selectedScale;
		} else {
			input.ToggleDraggingObject(false);
		}
		image.color = standardColor;
		cannotPurchaseDragOccuring = false;
	}

	protected override void FetchReferences () {

	}

	protected override void SetReferences () {
		image = GetComponent<Image>();
		standardColor = image.color;
		SetCost(cost);
		canvasGroup = GetComponent<CanvasGroup>();
	}

	void Toggle (bool isActive) {
		this.canvasGroup.alpha = isActive ? 1 : 0;
		this.canvasGroup.blocksRaycasts = isActive;
	}

	public void Hide () {
		Toggle(false);
	}

	public void Show () {
		Toggle(true);
	}

	public void SetCost (int cost) {
		this.cost = cost;
		purchaseCostText.text = this.cost.ToString();
	}

	public void OnPurchased () {
		WorldController.Instance.TrySpendMiniOrbs(cost);
	}

	protected override void HandleNamedEvent (string eventName) {

	}

	protected override void CleanupReferences () {

	}

	public void AddElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void RemoveElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void ShowElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void HideElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public IUIElement GetElementByID(string id) {
		throw new System.NotImplementedException();
	}

	public IUIElement GetParent (IUIElement element) {
		throw new System.NotImplementedException();
	}

	public IUIElement[] GetChildren (IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void OnPointerDown(int pointerID, Vector3 position) {
		throw new System.NotImplementedException();
	}

	public void OnPointerUp(int pointerID, Vector3 position) {
		throw new System.NotImplementedException();
	}

	public void OnPointerDrag(int pointerID, Vector3 position) {
		throw new System.NotImplementedException();
	}

	public void OnPointerEnter(int pointerID, Vector3 position) {
		throw new System.NotImplementedException();
	}

	public void OnPointerExit(int pointerID, Vector3 position) {
		throw new System.NotImplementedException();
	}
}
