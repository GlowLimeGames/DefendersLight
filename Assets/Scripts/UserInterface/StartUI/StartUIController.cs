/*
 * Authors: Ranjini Das, Isaiah Mann
 * Description: Controls the behaviour of the start screen
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartUIController : UIController {
	static bool applicationLoad = true;

	[SerializeField]
	Text highestWave;
	[SerializeField]
	Text playerLevel;

	[SerializeField]
	CanvasGroup splashScreen;
	[SerializeField]
	float splashStayTime;
	[SerializeField]
	float splashFadeTime;

	[SerializeField]
	UIButton newGameButton;

	protected override void SetReferences () {
		base.SetReferences ();
		SceneController.ReportSceneLoadComplete();
		setText();
		if (applicationLoad) {
			StartCoroutine(displaySplashScreen());
			applicationLoad = false;
		}
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
		if (data.HasWorldState) {
			newGameButton.Show();
		}
	}

	IEnumerator displaySplashScreen () {
		toggleCanvasGroup(splashScreen, true);
		yield return new WaitForSeconds(splashStayTime);
		float timer = 0;
		while (timer <= splashFadeTime) {
			splashScreen.alpha = Mathf.Lerp(1, 0, timer / splashFadeTime);
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		toggleCanvasGroup(splashScreen, false);
	}
}


