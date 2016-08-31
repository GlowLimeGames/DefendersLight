/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of a logical group of UI elements
 */

public interface IUIGroup : IUIElement {
	void SetLayout(UILayoutType layoutType);
	void SetAlpha(float opacity);
	void Sort(SortRule rule);
}