using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	void Awake () {
		SceneController.ReportSceneLoadComplete();
	}

	public void SwitchToPrototype() {
		SceneController.LoadGame();
    }
}


