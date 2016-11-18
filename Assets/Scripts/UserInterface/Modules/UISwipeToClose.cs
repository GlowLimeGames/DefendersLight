/*
 * Author(s): Isaiah Mann
 * Description: Makes a panel closeable by swiping
 * Notes: Assumes the panel is already at the edge of the screen
 */

using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class UISwipeToClose : UIModule, IBeginDragHandler, IDragHandler, IEndDragHandler {
	EventAction onCloseCallback;

	[SerializeField]
	float dragThresold;
	[SerializeField]
	float exitDistance = 200;
	[SerializeField]
	bool resetPositionOnClose;

	Vector3 startingPosition;

	[SerializeField] 
	Orientation orientation;
	[SerializeField]
	Direction dragDirection; // Potential Values if Horizontal: East, West; Potential Values if Vertical: North, South
	[SerializeField]
	float autoCloseSpeed; // Measured in Units per second

	InputController input;

	public void SubscribeToClose (EventAction action) {
		onCloseCallback += action;
	}

	public void UnsubscribeFromClose (EventAction action) {
		onCloseCallback += action;
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		startingPosition = transform.position;
		input = InputController.Instance;
	}

	public void OnBeginDrag (PointerEventData pointerEvent) {
		input.ToggleInputEnabled(false);
	}

	public void OnDrag (PointerEventData pointerEvent) {
		Vector3 pointer = pointerEvent.position;
		Vector3 pos = transform.position;
		if (orientation == Orientation.Vertical) {
			transform.Translate(new Vector3(0, pointer.y - pos.y, 0));
		} else if (orientation == Orientation.Horizontal) {
			transform.Translate(new Vector3(pointer.x - pos.x, 0, 0));
		}
		checkToCompleteClose();
	}

	public void OnEndDrag (PointerEventData pointerEvent) {
		input.ToggleInputEnabled(true);
	}

	public void ResetPosition () {
		transform.position = startingPosition;
	}

	bool shouldCompleteClose () {
		return Vector3.Distance(transform.position, startingPosition) >= dragThresold;
	}

	void checkToCompleteClose () {
		if (shouldCompleteClose()) {
			StartCoroutine(completeClose());
		}
	}

	IEnumerator completeClose () {
		float timer = 0;
		Vector3 beginPosition = transform.position;
		Vector3 endingPosition = startingPosition;
		if (dragDirection == Direction.West) {
			endingPosition.x -= exitDistance;
		} else if (dragDirection == Direction.East) {
			endingPosition.x += exitDistance;
		} else if (dragDirection == Direction.North) {
			endingPosition.y += exitDistance;
		} else if (dragDirection == Direction.South) {
			endingPosition.y -= exitDistance;
		}
		float time = Vector3.Distance(beginPosition, endingPosition) / autoCloseSpeed;
		while (timer <= time) {
			transform.position = Vector3.Lerp(beginPosition, endingPosition, timer / time);
			yield return new WaitForEndOfFrame();
			timer += Time.deltaTime;
		}
		callOnCloseCallback();
		if (resetPositionOnClose) {
			ResetPosition();
		}
	}

	void callOnCloseCallback () {
		if (onCloseCallback != null) {
			onCloseCallback();
		}
	}
}
