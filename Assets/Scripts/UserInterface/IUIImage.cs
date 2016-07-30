/*
 * Author(s): Isaiah Mann
 * Description: Template behaviour for a UI element containing an image
 */

using UnityEngine;

public interface IUIImage : IUIElement {
	void Set(Sprite sprite);
	void SetTint(Color color);
}
