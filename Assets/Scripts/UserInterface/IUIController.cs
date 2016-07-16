public interface IUserIntefaceController {
    void AddElement(IUIElement element);
    void RemoveElement(IUIElement element);
    void ShowElement(IUIElement element);
    void HideElement(IUIElement element);

    IUIElement GetElementByID(string id);
    IUIElement GetParent (IUIElement element);
    IUIElement[] GetChildren (IUIElement element);
}
