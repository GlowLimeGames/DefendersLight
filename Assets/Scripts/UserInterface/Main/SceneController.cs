/*
 * Author(s): Isaiah Mann
 * Description: Controls the navigation/loading of scenes
 */

using UnityEngine.SceneManagement;

public class SceneController : MannBehaviour {
	public static bool IsLoadingScene;
	public static bool IsPlayAgain {get; private set;}
	const string GAME_SCENE_NAME = "Game";
	const string START_SCENE_NAME = "StartScreen";
	const string GAME_OVER_SCENE_NAME = "GameOver";
	const string ABOUT_SCENE = "About";
	const string CREDITS_SCENE = "Credits";
	const string SETTINGS_SCENE = "Settings";
	const string ALMANAC_SCENE = "Almanac";
	// Loads start if a previous scene has not yet been set
	const string DEFAULT_PREVIOUS_SCENE = START_SCENE_NAME;
	static string previousScene = DEFAULT_PREVIOUS_SCENE;

	public static void LoadGame (bool isPlayAgain = false) {
		LoadScene(GAME_SCENE_NAME);
		IsPlayAgain = isPlayAgain;
	}

	public static void LoadGameOver () {
		cleanupInGameReferences();
		EventController.Event(EventType.LoadGameOver);
		LoadScene(GAME_OVER_SCENE_NAME);
	}

	public static void LoadStart () {
		cleanupInGameReferences();
		IsLoadingScene = true;
		LoadScene(START_SCENE_NAME);
	}

	public static void LoadAbout () {
		cleanupInGameReferences();
		LoadScene(ABOUT_SCENE);
	}

	public static void LoadCredits () {
		cleanupInGameReferences();
		LoadScene(CREDITS_SCENE);
	}

	public static void LoadSettings () {
		LoadScene(SETTINGS_SCENE);
	}

	public static void LoadAlmanac () {
		LoadScene(ALMANAC_SCENE);
	}

	public static void LoadScene (string sceneName) {
		previousScene = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene(sceneName);
	}

	// Loads start if a previous scene has not yet been set
	public static void LoadPreviousScene () {
		LoadScene(previousScene);
	}

	public static void ReportSceneLoadComplete () {
		IsLoadingScene = false;
	}

	static void cleanupInGameReferences () {
		IsPlayAgain = false;
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