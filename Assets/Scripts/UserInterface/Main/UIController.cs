/*
 * Author(s): Isaiah Mann
 * Description: The base class that UIController's inherit from
 */

public abstract class UIController : MannBehaviour {
	protected InputController input;
	protected DataController data;

	public void LoadStartScreen () {
		SceneController.LoadStart();
	}

	public void LoadGame (bool isPlayAgain) {
		SceneController.LoadGame(isPlayAgain);
	}

	public void LoadAbout () {
		SceneController.LoadAbout();
	}

	public void LoadCredits () {
		SceneController.LoadCredits();
	}

	protected override void SetReferences () {
		// NOTHING
	}

	protected override void FetchReferences () {
		input = InputController.Instance;
		data = DataController.Instance;
	}

	protected override void HandleNamedEvent (string eventName) {
		// NOTHING
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

	public void OpenURL (string url) {
		UnityEngine.Application.OpenURL(url);
	}
		
}