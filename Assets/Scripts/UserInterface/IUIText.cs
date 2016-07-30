/*
 * Author(s): Isaiah Mann
 * Description: Describes a UI text element within the game
 * Note: Should be tunable via JSON
 */

using UnityEngine;

public interface IUIText : IUIElement {
	string GetText();
	void SetText(string text);
	void SeColor(Color color);
	void SetFontSize(int fontSize);
	void SetFont(Font font);
}