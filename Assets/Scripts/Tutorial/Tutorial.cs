/*
 * Author(s): Isaiah Mann
 * Description: Tutorial: Can be read in from JSON
 */

using UnityEngine;

[System.Serializable]
public class Tutorial {
	public string Name;
	public TutorialStep[] Steps;
	int currentStepIndex = 0;
	TutorialStep currentStep;
	public TutorialStep CurrentStep {
		get {
			if (currentStep == null) {
				currentStep = Steps[0];
			}
			return currentStep;
		}
	}

	public TutorialStep NextStep () {
		return deltaStep(1);
	}
		
	public bool HasNext () {
		return IntUtil.InRange(currentStepIndex + 1, Steps.Length);
	}

	public bool HasPrevious () {
		return IntUtil.InRange(currentStepIndex - 1, Steps.Length);
	}

	public TutorialStep PreviousStep () {
		return deltaStep(-1);
	}

	public void Reset () {
		currentStepIndex = 0;
		setStepToCurrentIndex();
	}

	TutorialStep deltaStep (int delta) {
		if (IntUtil.InRange(currentStepIndex + delta, Steps.Length)) {
			currentStepIndex += delta;
			return setStepToCurrentIndex();
		} else {
			return null;
		}
	}

	TutorialStep setStepToCurrentIndex () {
		currentStep = Steps[currentStepIndex];
		return currentStep;
	}
		
	public Sprite GetCurrentSprite () {
		return GetStepSprite(currentStep);
	}

	public Sprite GetStepSprite (TutorialStep step) {
		if (!step.Sprite) {
			step.Sprite = Resources.Load<Sprite>(step.Image);
		}
		return step.Sprite;
	}
}
