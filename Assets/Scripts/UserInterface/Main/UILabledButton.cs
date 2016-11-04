/*
 * Author(s): Isaiah Mann
 * Description: Describes a button with a text label
 */

using UnityEngine.UI;

public class UILabledButton : UIButton {
	protected Text label;

	public void Set (string text, EventAction clickAction, bool clearPreviousClickActions = true) {
		if (clearPreviousClickActions) {
			UnsubscribeAllClickActions();
		}
		SetText(text);
		SubscribeToClick(clickAction);
	}


	public void SetText (string text) {
		label.text = text;
	}

	protected override void SetReferences () {
		base.SetReferences();
		label = GetComponentInChildren<Text>();
	}
}
