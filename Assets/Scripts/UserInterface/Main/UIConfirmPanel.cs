/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using UnityEngine.UI;

public class UIConfirmPanel : UIElement {
	[SerializeField]
	bool closeOnCancel;
	[SerializeField]
	bool clearEventsOnHide;
	[SerializeField]
	bool closeOnConfirm;
	[SerializeField]
	Text confirmText;
	string confirmTextFormat = "Are you sure {0}?";
	EventAction onCancel;
	EventAction onConfirm;

	protected override void SetReferences () {
		base.SetReferences ();
		checkToSubscribeDefaultEvents();
	}

	void checkToSubscribeDefaultEvents () {
		if (closeOnCancel) {
			onCancel += Hide;
		}
		if (closeOnConfirm) {
			onConfirm += Hide;
		}
	}

	public void SetConfirmTextFromFormat (string insert) {
		confirmText.text = string.Format(confirmTextFormat, insert);
	}

	public void ClearButtonEvents () {
		onCancel = null;
		onConfirm = null;
		checkToSubscribeDefaultEvents();
	}

	public void SubscribeToCancel (EventAction action) {
		onCancel += action;
	}

	public void UnsubscribeFromCancel (EventAction action) {
		onCancel -= action;
	}


	public void SubscribeToConfirm (EventAction action) {
		onConfirm += action;
	}
		
	public void UnsubscribeFromConfirm (EventAction action) {	
		onCancel += action;
	}

	public void Cancel () {
		callOnCancel();
	}

	public void Confirm () {
		callOnConfirm();
	}

	public override void Hide () {
		base.Hide ();
		if (clearEventsOnHide) {
			ClearButtonEvents();
		}
	}

	void callOnCancel () {
		if (onCancel != null) {
			onCancel();
		}
	}

	void callOnConfirm () {
		if (onConfirm != null) {
			onConfirm();
		}
	}
}
