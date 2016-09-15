/*
 * Author(s): Isaiah Mann
 * Description: Adjusts the display of a units health bar
 */

using UnityEngine;
using System.Collections;

public class HealthBarBehaviour : MannBehaviour {
	[SerializeField]
	RectTransform healthBarFill;

	Vector3 healthBarOrigin;

	// Float must be between 0 and 1
	public void SetHealthDisplay (float healthFraction) {
		Vector3 current = healthBarFill.localScale;
		healthBarFill.localScale = new Vector3(healthFraction, current.y, current.z);
		healthBarFill.localPosition = healthBarOrigin;;
		healthBarFill.localPosition += Vector3.left * ((1 - healthFraction)/2f);
	}

	protected override void SetReferences() {
		healthBarOrigin = healthBarFill.localPosition;
	}

	protected override void FetchReferences() {

	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent(string eventName) {

	}

}
