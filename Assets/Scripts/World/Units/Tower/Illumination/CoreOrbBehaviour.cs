/*
 * Author(s): Isaiah Mann
 * Description: The behaviour of the core orb in game
 * Notes: Within the current design, only one core orb should ever exist
 */

using UnityEngine;
using System.Collections;

public class CoreOrbBehaviour : IlluminationTowerBehaviour {
    
	protected override void SetReferences() {
		base.SetReferences();
    }
		
    protected override void HandleNamedEvent(string eventName) {
		base.HandleNamedEvent(eventName);
    }

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

	public override void Attack(ActiveObjectBehaviour activeAgent) {
		base.Attack(activeAgent);
	}

	public override void Damage(int damage) {
		base.Damage(damage);
    }

    public override void Destroy() {
		base.Destroy();
    }

	public override void Heal(int healthPoints) {
		base.Heal(healthPoints);
    }
}
