/*
 * Author(s): Isaiah Mann
 * Description: Controls the behaviour of the settings screen
 */

using UnityEngine;

public class SettingsUIController : UIController {
	[SerializeField]
	string confirmDeleteDataText = "you want to delete all data";
	[SerializeField]
	ToggleableUIButton sfxToggle;
	[SerializeField]
	ToggleableUIButton musicToggle;
	[SerializeField]
	UIConfirmPanel confirmPanel;

	protected override void SetReferences () {
		base.SetReferences ();
		if (SettingsUtil.SFXMuted) {
			sfxToggle.Toggle();
		}
		if (SettingsUtil.MusicMuted) {
			musicToggle.Toggle();
		}
	}

	public void ShowConfirmResetGame () {
		confirmPanel.SubscribeToConfirm(ResetGame);
		confirmPanel.SetConfirmTextFromFormat(confirmDeleteDataText);
		confirmPanel.Show();
	}
		
	public void ResetGame () {
		data.ResetGame();
	}
}
