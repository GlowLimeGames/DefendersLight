/*
 * Author: Isaiah Mann
 * Description: Interface that any interactable element in the game should element (UI and game world)
 */

using UnityEngine;

public interface IInteractive {
	void OnPointerDown(int pointerID, Vector3 position);
	void OnPointerUp(int pointerID, Vector3 position);
	void OnPointerDrag(int pointerID, Vector3 position);
	void OnPointerEnter(int pointerID, Vector3 position);
	void OnPointerExit(int pointerID, Vector3 position);
}