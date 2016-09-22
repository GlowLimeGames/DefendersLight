/*
 * Authors: Ranjini Das, Isaiah Mann
 * Description: Controls the behaviour of the start screen
 */

using UnityEngine;
using System.Collections;

public class StartUIController : UIController {
	protected override void SetReferences () {
		base.SetReferences ();
		SceneController.ReportSceneLoadComplete();
	}
}


