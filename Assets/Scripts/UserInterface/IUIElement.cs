/*
 * Author(s): Isaiah Mann
 * Description: Describes the public functioanlity of a generic UIElement
 */

public interface IUIElement {
	string GetID();
	void Show();
	void Hide();
	void SetParent(IUIElement parent);
	void AddChild(IUIElement child);
	void RemoveChild(IUIElement child);
	IUIElement[] GetChildren();
	IUIElement GerParent();
}
