/*
 * Author(s): Isaiah Mann
 * Description: The behaviour of the core orb in game
 * Notes: Within the current design, only one core orb should ever exist
 */

using UnityEngine;
using System.Collections;

public class CoreOrbBehaviour : IlluminationTowerBehaviour {
	public const string CORE_ORB_KEY = "Core Orb";
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

	public override void Attack (ActiveObjectBehaviour activeAgent, int damage) {
		base.Attack (activeAgent, damage);
		EventController.Event(EventType.CoreOrbAttack);
	}

	public override void Destroy () {
		CleanupReferences();	
	}
}
