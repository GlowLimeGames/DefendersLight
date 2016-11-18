/*
 * Author(s): Isaiah Mann
 * Description: Describes the public functioanlity of a generic UIElement
 */

public interface IUIElement : IJSONDeserializable {
	string ID {get;}
	IUIElement[] Children{get;}
	IUIElement Parent{get;}
	bool Scrollable{get; set;}
	bool OverflowEnabled{get; set;}
	bool Interactive{get; set;}
	UIDimensions Dimensions{get;}

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
	IUIElement GetChild(string id);
}
