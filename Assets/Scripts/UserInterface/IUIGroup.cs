public interface IUIGroup : IUIElement {
	void SetLayout(UILayoutType layoutType);
	void SetAlpha(float opacity);
	void Sort(SortRule rule);
}