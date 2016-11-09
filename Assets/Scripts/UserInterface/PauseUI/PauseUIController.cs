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

	public void TogglePause () {
		world.TogglePause();	
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		world = WorldController.Instance;
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