/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a class that can be initialized from JSON
 */

public interface IUIController : IController {
    void AddElement(IUIElement element);
    void RemoveElement(IUIElement element);
    void ShowElement(IUIElement element);
    void HideElement(IUIElement element);

    IUIElement GetElementByID(string id);
    IUIElement GetParent (IUIElement element);
    IUIElement[] GetChildren (IUIElement element);
}
