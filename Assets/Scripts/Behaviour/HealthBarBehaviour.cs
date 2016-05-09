using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarBehaviour : MannBehaviour {
	[SerializeField]
	Image HealthBarFill;

	// Float must be between 0 and 1
	public void SetHealthDisplay (float healthFraction) {
		HealthBarFill.fillAmount = healthFraction;
	}

	protected override void SetReferences() {

	}

	protected override void FetchReferences() {

	}

	protected override void HandleNamedEvent(string eventName) {

	}

}
