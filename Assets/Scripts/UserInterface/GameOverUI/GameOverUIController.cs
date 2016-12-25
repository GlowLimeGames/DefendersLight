/*
 * Author(s): Isaiah Mann
 * Description: Controls the game over UI
 */

using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : UIController {
	[SerializeField]
	Text enemiesKilled;
	[SerializeField]
	Text wavesSurvivied;
	[SerializeField]
	GameObject newHighestWave;

	protected override void FetchReferences () {
		base.FetchReferences();
		DataController data;
		// Assignment is intentional
		if (data = DataController.Instance) {
			enemiesKilled.text = string.Format(enemiesKilled.text, data.EnemiesKilled);
			wavesSurvivied.text = string.Format(wavesSurvivied.text, data.WavesSurvivied);
			newHighestWave.SetActive(data.HighestWaveReachedInSession);
			data.ResetWorld();
		}
	}
}
