/*
 * Author(s): Isaiah Mann
 * Description: Makes a panel closeable by swiping
 * Notes: Assumes the panel is already at the edge of the screen
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(CanvasGroup))]
public class UISwipeToClose : UIModule, IBeginDragHandler, IDragHandler, IEndDragHandler {
	const float FAKE_DELTA_TIME = 0.04166666667f;
	EventAction onCloseCallback;
	CanvasGroup canvas;
	bool autoScrollLock = false;
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

	protected override void SetReferences () {
		base.SetReferences ();
		canvas = GetComponent<CanvasGroup>();
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
		if (autoScrollLock) {
			return;
		}

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
		canvas.interactable = false;
		autoScrollLock = true;
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
			if (Time.timeScale == 0) {
				// Necessary if the game is paused because Time.deltaTime will always equal 0 if the timeScale is 0
				timer += FAKE_DELTA_TIME;
			} else {
				timer += Time.deltaTime;
			}
		}
		callOnCloseCallback();
		if (resetPositionOnClose) {
			ResetPosition();
		}
		canvas.interactable = true;
		autoScrollLock = false;
	}

	void callOnCloseCallback () {
		if (onCloseCallback != null) {
			onCloseCallback();
		}
	}
}
