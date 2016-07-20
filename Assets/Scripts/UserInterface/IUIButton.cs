/*
 * Author: Isaiah Mann
 * Description: Expected behaviour of a button
 */

public interface IUIButton : IUIInteractiveElement {
	// Puts button into "Down" state until "ButtonUp" is called
	void ButtonDown();
	void ButtonUp();
	bool IsDown();

	// Combines functionality of start and end press
	void Click();

	// Called when the button Click method is called
	void AddClickEvent(EventController.Action action);
	// Called every frame the button is held down
	void AddButtonHeldEvent(EventController.Action action);
	void AddOnDownEvent(EventController.Action action);
	void AddOnUpEvent(EventController.Action action);
}
