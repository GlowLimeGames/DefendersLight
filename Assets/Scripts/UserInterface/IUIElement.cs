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
	void AddChildren(IUIElement[] children);
	void RemoveChild(IUIElement child);
	void AddImage (IUIImage image);
	void AddText (IUIText text);
	void SetSize(int width, int height);
	void SetSize(UIDimensions dimensions);
	void ToggleScrollable(bool isScrollable);
	void ToggleOverflow(bool overflowEnabled);
	void SetInteractive(bool isInteractive);
	bool IsScrollable();
	bool IsOverflowEnabled();
	bool IsInteractive();
	IUIElement[] GetChildren();
	IUIElement GetParent();
	IUIElement GetChild(string id);
}
