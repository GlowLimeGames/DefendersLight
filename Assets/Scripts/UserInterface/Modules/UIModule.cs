/*
 * Author(s): Isaiah Mann
 * Description: Represents a UI Module
 */

using UnityEngine;

public class UIModule : MannBehaviour {
	protected RectTransform rTransform;

	protected override void SetReferences () {
		base.SetReferences ();
		rTransform = GetComponent<RectTransform>();
	}

	protected override void FetchReferences () {
		// NOTHING
	}

	protected override void HandleNamedEvent (string eventName) {
		// NOTHING
	}
}
