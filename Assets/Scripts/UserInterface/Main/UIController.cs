/*
 * Author(s): Isaiah Mann
 * Description: The base class that UIController's inherit from
 */

public abstract class UIController : MannBehaviour, IUIController {
	public void LoadStartScreen () {
		SceneController.LoadStart();
	}

	public void LoadGame () {
		SceneController.LoadGame();
	}


	protected override void SetReferences () {

	}

	protected override void FetchReferences () {

	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent (string eventName) {

	}

	public void PlayClickSound () {
		EventController.Event(EventType.Click);
	}

	public void ToggleMusic () {
		SettingsUtil.ToggleMusicMuted();
	}

	public void ToggleSFX () {
		SettingsUtil.ToggleSFXMuted();
	}

	public void AddElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void RemoveElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void ShowElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void HideElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public IUIElement GetElementByID(string id) {
		throw new System.NotImplementedException();
	}

	public IUIElement GetParent (IUIElement element) {
		throw new System.NotImplementedException();
	}

	public IUIElement[] GetChildren (IUIElement element) {
		throw new System.NotImplementedException();
	}
}