/*
 * Author(s): Isaiah Mann
 * Description: Describes a UI text element within the game
 * Note: Should be tunable via JSON
 */

using UnityEngine;

public interface IUIText : IUIElement {
	string Text{get; set;}
	Color Color{get; set;}
	int FontSize{get; set;}
	void SetFont(Font font);
}