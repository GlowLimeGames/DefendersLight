/*
 * Author(s): Isaiah Mann
 * Description: Loads and runs the tutorial
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TutorialController : SingletonController<TutorialController> {
	public const string INTRO_TUTORIAL_KEY = "IntroductoryTutorial";
	CanvasGroup canvas;

	[SerializeField]
	bool autoStartIntroTutorial;

	[SerializeField]
	Image stepImage;
	[SerializeField]
	Text stepTitle;
	[SerializeField]
	Text stepBody;
	[SerializeField]
	Button previousButton;
	[SerializeField]
	Button nextButton;
	[SerializeField]
	Image nextButtonIcon;
	[SerializeField]
	Sprite closeIcon;
	[SerializeField]
	Sprite arrowIcon;

	string[] TutorialKeys = new string[]{INTRO_TUTORIAL_KEY};
	Dictionary<string, Tutorial> tutorials = new Dictionary<string, Tutorial>();
	Tutorial current;
	public bool HasActiveTutorial {
		get {
			return current != null;
		}
	}

	void UpdateCurrentTutorial () {
		UpdateTutorial(current);
	}

	public void UpdateTutorial (Tutorial tutorial) {
		TutorialStep currentStep = tutorial.CurrentStep;
		Sprite currentImage = tutorial.GetCurrentSprite();
		stepTitle.text = currentStep.Title;
		stepImage.sprite = currentImage;
		stepBody.text = currentStep.Body;
		previousButton.interactable = tutorial.HasPrevious();
		nextButtonIcon.sprite = tutorial.HasNext() ? arrowIcon : closeIcon;
	}

	public void PlayTutorial (string key) {
		if (tutorials.TryGetValue(key, out current)) {
			Show();
			current.Reset();
			UpdateCurrentTutorial();
			if (world) {
				world.Pause();
			}
		}
	}

	public void Next (bool autoEndIfNoNext = true) {
		if (HasActiveTutorial && current.HasNext()) {
			current.NextStep();
			UpdateCurrentTutorial();
		} else if (autoEndIfNoNext) {
			endTutorial();
		}
	}

	public void SkipTutorial () {
		endTutorial();
	}

	void endTutorial () {
		current = null;
		Close();
		if (world) {
			world.Resume();
		}
	}

	public void Close () {
		toggleCanvasGroup(canvas, false);
		gameObject.SetActive(false);
	}

	public void Show () {
		gameObject.SetActive(true);
		toggleCanvasGroup(canvas, true);
	}

	public void Previous () {
		if (HasActiveTutorial && current.HasPrevious()) {
			current.PreviousStep();
			UpdateCurrentTutorial();
		}
	}

	protected override void SetReferences () {
		base.SetReferences ();
		canvas = GetComponent<CanvasGroup>();
	}

	protected override void FetchReferences () {
		if (isSingleton) {
			base.FetchReferences ();
			tutorials = loadTutorials(false, TutorialKeys);
			if (autoStartIntroTutorial) {
				PlayTutorial(INTRO_TUTORIAL_KEY);
			}
		}
	}

	Dictionary<string, Tutorial> loadTutorials (bool overwrite, params string[] keys) {
		Dictionary<string, Tutorial> tutorials = new Dictionary<string, Tutorial>();
		foreach (string key in keys) {
			Tutorial tutorial = JsonUtility.FromJson<Tutorial>(data.RetrieveJSONFromResources(key));
			if (!tutorials.ContainsKey(key)) {
				tutorials.Add(key, tutorial);
			} else if (overwrite) {
				tutorials[key] = tutorial;
			}
		}
		return tutorials;
	}
}