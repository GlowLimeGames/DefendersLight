/*
 * Authors: Ranjini Das, Isaiah Mann
 * Description: Controls the behaviour of the start screen
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartUIController : UIController {
	[SerializeField]
	Text highestWave;
	[SerializeField]
	Text playerLevel;

	protected override void SetReferences () {
		base.SetReferences ();
		SceneController.ReportSceneLoadComplete();
		setText();
	}

	void setText () {
		DataController data = DataController.Instance;
		if (data) {
			highestWave.text = string.Format(highestWave.text, data.HighestWave);
			playerLevel.text = string.Format(playerLevel.text, data.PlayerLevel);
		}
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		EventController.Event(EventType.LoadStart);
	}
}


