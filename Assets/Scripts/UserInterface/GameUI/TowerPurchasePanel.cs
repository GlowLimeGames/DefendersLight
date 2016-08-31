/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerPurchasePanel : MannBehaviour, IUIInteractiveElement, IBeginDragHandler, IDragHandler, IEndDragHandler {
	TowerPurchasePanelController controller;
	Image image;
	Color standardColor;
	float selectedScale = 1.05f;

	public void InitWithController (TowerPurchasePanelController controller) {
		this.controller = controller;
	}

	public void OnBeginDrag (PointerEventData pointerEvent) {
		controller.HandleBeginDragPurchase(pointerEvent, this);
		image.color = Color.gray;
		transform.localScale *= selectedScale;
	}

	public void OnDrag (PointerEventData pointerEvent) {
		controller.HandleDragPurchase(pointerEvent, this);
	}

	public void OnEndDrag (PointerEventData pointerEvent) {
		controller.HandleEndDragPurchase(pointerEvent, this);
		image.color = standardColor;
		transform.localScale /= selectedScale;
	}

	protected override void FetchReferences () {

	}

	protected override void SetReferences () {
		image = GetComponent<Image>();
		standardColor = image.color;
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
