/*
 * Author(s): Isaiah Mann
 * Description: The behaviour of the core orb in game
 * Notes: Within the current design, only one core orb should ever exist
 */

using UnityEngine;
using System.Collections;

public class CoreOrbBehaviour : IlluminationTowerBehaviour {
	protected override void CleanupReferences () {
		base.CleanupReferences ();
		if (!SceneController.IsLoadingScene) {
			if (DataController.Instance) {
				DataController.Instance.SaveGame();
			}
			// Immediately load game over when the core orb is destroyed:
			SceneController.LoadGameOver();
		}
	}
}
