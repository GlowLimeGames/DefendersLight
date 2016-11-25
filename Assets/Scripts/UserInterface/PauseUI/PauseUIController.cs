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
	UIPanelSwipe swipeToClosePause;
	CanvasGroup pauseScreenCanvas;
	bool isPaused {
		get {
			return world.IsPaused;
		}
	}
	protected override void SetReferences () {
		base.SetReferences();
		if (SettingsUtil.SFXMuted) {
			sfxToggle.Toggle();
		}
		if (SettingsUtil.MusicMuted) {
			musicToggle.Toggle();
		}
		pauseScreenCanvas = GetComponentInChildren<CanvasGroup>();
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
		swipeToClosePause.SubscribeToBeginClose(delegate () {
			if (cheatPanelIsOpen()) {
				ToggleCheatPanel();	
			}
		});
	}

	public void TogglePauseScreen () {
		pauseScreen.SetActive(isPaused);
		toggleCanvasGroup(pauseScreenCanvas, isPaused);
		if (isPaused) {
			swipeToClosePause.RequestOpen();
		} else {
			cheatPanel.SetActive(false);
		}
	}

	public void ToggleCheatPanel () {
		cheatPanel.SetActive(!cheatPanel.activeSelf);

	}

	bool cheatPanelIsOpen () {
		return cheatPanel.activeSelf;
	}

	public void QuitGame () {
		Time.timeScale = 1;
		LoadStartScreen();
	}

    
}