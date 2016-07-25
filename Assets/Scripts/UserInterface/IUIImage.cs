using UnityEngine;

public interface IUIImage : IUIElement {
	void Set(Sprite sprite);
	void SetTint(Color color);
}
