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
public class UIPanelSwipe : UIModule, IBeginDragHandler, IDragHandler, IEndDragHandler {
	EventAction onCloseCallback;
	CanvasGroup canvas;
	bool autoScrollLock = false;
	[SerializeField]
	float dragThresold;
	[SerializeField]
	float exitDistance = 200;
	[SerializeField]
	bool resetPositionOnClose;
	[SerializeField]
	bool startsClosed = true;
	bool closed = true;
	Vector3 startingPosition;

	[SerializeField] 
	Orientation orientation;
	[SerializeField]
	Direction dragDirection; // Potential Values if Horizontal: East, West; Potential Values if Vertical: North, South
	[SerializeField]
	float autoCloseSpeed; // Measured in Units per second
	[SerializeField]
	float enterSpeed = 1;
	bool closedOnDrag = false;

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
		closed = startsClosed;
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		startingPosition = transform.position;
		if (closed) {
			setToClosedPosition();
		}
		input = InputController.Instance;
	}

	// Should only be called after startingPosition is set correctly
	void setToClosedPosition () {
		transform.position = startingPosition + (Vector3) DirectionUtil.VectorFromDirection(dragDirection) * exitDistance;
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
			float deltaY = pointer.y - pos.y;
			if (dragDirection == Direction.North && deltaY > 0 || dragDirection == Direction.South && deltaY < 0) {
				transform.Translate(new Vector3(0, deltaY, 0));
			}
		} else if (orientation == Orientation.Horizontal) {
			float deltaX = pointer.x - pos.x;
			if (dragDirection == Direction.West && deltaX < 0 || dragDirection == Direction.East && deltaX > 0) {
				transform.Translate(new Vector3(deltaX, 0, 0));
			}
		}
		checkToCompleteClose();
	}

	public void OnEndDrag (PointerEventData pointerEvent) {
		input.ToggleInputEnabled(true);
		if (!closedOnDrag) {
			StartCoroutine(snapBack());
		} else {
			closedOnDrag = false;
		}
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
			closedOnDrag = true;
		}
	}
		
	IEnumerator snapBack () {
		autoScrollLock = true;
		float timer = 0;
		Vector3 beginPosition = transform.position;
		Vector3 endingPosition = startingPosition;
		float time = Vector3.Distance(beginPosition, endingPosition) / autoCloseSpeed;
		while (time != 0 && timer <= time) {
			transform.position = Vector3.Lerp(beginPosition, endingPosition, timer / time);
			yield return new WaitForEndOfFrame();
			timer += WorldController.Paused ? FAKE_DELTA_TIME : Time.fixedDeltaTime;
		}
		ResetPosition();
		autoScrollLock = false;
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
			timer += WorldController.Paused ? FAKE_DELTA_TIME : Time.fixedDeltaTime;
		}
		callOnCloseCallback();
		if (resetPositionOnClose) {
			ResetPosition();
		}
		canvas.interactable = true;
		autoScrollLock = false;
		closed = true;
	}

	IEnumerator animatedOpen () {
		canvas.interactable = false;
		autoScrollLock = true;
		float timer = 0;
		Vector3 beginPosition = transform.position;
		Vector3 endingPosition = startingPosition;
		float time = Vector3.Distance(beginPosition, endingPosition) / enterSpeed;
		while (time != 0 && timer <= time) {
			transform.position = Vector3.Lerp(beginPosition, endingPosition, timer / time);
			yield return new WaitForEndOfFrame();
			timer += WorldController.Paused ? FAKE_DELTA_TIME : Time.fixedDeltaTime;
		}
		ResetPosition();
		canvas.interactable = true;
		autoScrollLock = false;
		closed = false;
	}
		
	public void RequestOpen () {
		if (closed) {
			StartCoroutine(animatedOpen());
		}
	}

	void callOnCloseCallback () {
		if (onCloseCallback != null) {
			onCloseCallback();
		}
	}
}
