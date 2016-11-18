/*
 * Author(s): Isaiah Mann
 * Description: Abstract class to represent and element in the UI
 */

public abstract class UIElement : MannBehaviour {
	protected override void FetchReferences () {
		// NOTHING
	}

	protected override void HandleNamedEvent (string eventName) {
		// NOTHING
	}

	public virtual void Hide () {
		gameObject.SetActive(false);
	}


	public virtual void Show () {
		gameObject.SetActive(true);
	}

	public void PlayClickSound () {
		EventController.Event(EventType.Click);
	}
}