/*
 * Author(s): Isaiah Mann
 * Description: Controls the navigation/loading of scenes
 */

using UnityEngine.SceneManagement;

public class SceneController : MannBehaviour {
	public static bool IsLoadingScene;
	const string GAME_SCENE_NAME = "Prototype";
	const string START_SCENE_NAME = "StartScreen";
	const string GAME_OVER_SCENE_NAME = "GameOver";

	public static void LoadGame () {
		SceneManager.LoadScene(GAME_SCENE_NAME);
	}

	public static void LoadGameOver () {
		SceneManager.LoadScene(GAME_OVER_SCENE_NAME);
	}

	public static void LoadStart () {
		IsLoadingScene = true;
		SceneManager.LoadScene(START_SCENE_NAME);
	}

	public static void ReportSceneLoadComplete () {
		IsLoadingScene = false;
	}

	protected override void SetReferences () {
		// NOTHING
	}

	protected override void FetchReferences () {
		// NOTHING
	}

	protected override void CleanupReferences () {
		// NOTHING
	}

	protected override void HandleNamedEvent (string eventName) {
		// NOTHING
	}
}