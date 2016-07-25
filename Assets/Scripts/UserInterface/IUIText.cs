using UnityEngine;

public interface IUIText : IUIElement {
	string GetText();
	void SetText(string text);
	void SeColor(Color color);
	void SetFontSize(int fontSize);
	void SetFont(Font font);
}