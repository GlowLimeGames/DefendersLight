/*
 * Author(s): Isaiah Mann
 * Description: Describes a button behaviour which can be toggled and off
 */

using UnityEngine;
using UnityEngine.UI;

public class ToggleableUIButton : UILabledButton {
	Color buttonUnselectedColor;
	Color buttonSelectedColor;

	[SerializeField]
	bool shouldToggleImage;
	[SerializeField]
	Image toggleImage;
	[SerializeField]
	Sprite imageOn;
	[SerializeField]
	Sprite imageOff;

	public bool ShowToggle;
	bool toggled = false;
	EventAction toggleOffAction;
	Image buttonImage;
	public bool IsToggled {
		get {
			return toggled;
		}
	}

	public void SubscribeToggleOffAction (EventAction toggleAction) {
		toggleOffAction += toggleAction;
	}

	public void UnsubscribeToggleOffAction (EventAction toggleAction) {
		toggleOffAction -= toggleAction;
	}
		
	public void Toggle () {
		toggled = !toggled;
		if (ShowToggle) {
			if (toggled) {
				if (shouldToggleImage) {
					toggleImage.sprite = imageOn;
				}
				buttonImage.color = buttonSelectedColor;
			} else {
				if (shouldToggleImage) {
					toggleImage.sprite = imageOff;
				}
				buttonImage.color = buttonUnselectedColor;
			}
		}
	}

	protected virtual void setToggle (bool isToggled) {
		toggled = isToggled;
	}

	protected override void executeClick () {
		Toggle();
		if (toggled) {
			base.executeClick ();
		} else {
			executeToggleOff();
		}
	}

	protected virtual void executeToggleOff () {
		if (toggleOffAction != null) {
			toggleOffAction();
		}
	}

	protected override void SetReferences () {
		base.SetReferences ();
		buttonImage = GetComponent<Image>();
		buttonUnselectedColor = buttonImage.color;
		buttonSelectedColor = Color.Lerp(buttonImage.color, Color.black, 0.5f);
	}
}
