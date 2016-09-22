/*
 * Author(s): Isaiah Mann
 * Description: Controls the game over UI
 */

using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : UIController, IUIController {
	[SerializeField]
	Text enemiesKilled;
	[SerializeField]
	Text wavesSurvivied;

	protected override void FetchReferences () {
		base.FetchReferences();
		if (DataController.Instance) {
			enemiesKilled.text = string.Format(enemiesKilled.text, DataController.Instance.EnemiesKilled);
			wavesSurvivied.text = string.Format(wavesSurvivied.text, DataController.Instance.WavesSurvivied);
			DataController.Instance.ResetGame();
		}
	}
}