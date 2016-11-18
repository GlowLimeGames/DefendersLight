/*
 * Author(s): Isaiah Mann
 * Description: Controls the pause screen behaviour
 */

using UnityEngine;

public class PauseUIController : UIController {
	WorldController world;
	[SerializeField]
	GameObject pauseScreen;
	[SerializeField]
	GameObject cheatPanel;
	[SerializeField]
	ToggleableUIButton sfxToggle;
	[SerializeField]
	ToggleableUIButton musicToggle;
	[SerializeField]
	UISwipeToClose swipeToClosePause;

	protected override void SetReferences () {
		base.SetReferences();
		if (SettingsUtil.SFXMuted) {
			sfxToggle.RefreshReferences();
			sfxToggle.Toggle();
		}
		if (SettingsUtil.MusicMuted) {
			musicToggle.RefreshReferences();
			musicToggle.Toggle();
		}
	}

    public void TogglePause () {
		world.TogglePause();	
	}

	public void Unpause () {
		world.Resume();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		world = WorldController.Instance;
		swipeToClosePause.SubscribeToClose(Unpause);
		swipeToClosePause.SubscribeToClose(TogglePauseScreen);
	}

	public void TogglePauseScreen () {
		pauseScreen.SetActive(!pauseScreen.activeSelf);
		if (!pauseScreen.activeSelf) {
			cheatPanel.SetActive(false);
		}
	}

	public void ToggleCheatPanel () {
		cheatPanel.SetActive(!cheatPanel.activeSelf);
	}

	public void QuitGame () {
		Time.timeScale = 1;
		LoadStartScreen();
	}

    
}