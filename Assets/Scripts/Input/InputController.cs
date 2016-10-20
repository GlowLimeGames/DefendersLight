﻿/*
 * Author(s): Isaiah Mann
 * Description: Handles player touch input to the game. Single input system to handle both mouse and touch input
 */

using UnityEngine;
using System;
using System.Collections.Generic;

public class InputController : Controller {
	public static InputController Instance;
	const int MOUSE_ID = int.MaxValue;
	bool inputEnabled = true;
	bool isDraggingObject = false;
	InputPointer[] pointersInPreviousFrame = new InputPointer[0];
	InputPointer previousSwipingPointer = null;
	public float SwipeTolerance = 0.05f;
	public float MaxPanSpeed = 0.1f;
	public float PanAcceleration = 0.001f;
	float panSpeed = 0;
	Vector3 swipeDirection;
	new CameraController camera;

	void Update () {
		if (inputEnabled) {
			HandleInput();
		}
	}

	public void ToggleInputEnabled (bool inputEnabled) {
		this.inputEnabled = inputEnabled;
	}

	public void ToggleDraggingObject (bool isDragging) {
		this.isDraggingObject = isDragging;
	}

	void HandleInput () {
		InputPointer[] pointers = GetPointers();
		if (HasPointersDown()) {
			HandlePointersDown(pointers);
		} else {
			previousSwipingPointer = null;
			panSpeed = 0;
		}
		pointersInPreviousFrame = pointers;
	}


	void HandlePointersDown (InputPointer[] pointers) {
		InputPointer swipingPointer;
		if (PointerPressed()) {			
			HandlePointerPressed(pointers);
		} else if (isSwiping(pointers, SwipeTolerance, out swipingPointer)) {
			handleSwipe(swipingPointer);
		}
	}

	void HandlePointerPressed (InputPointer[] pointers) {
		InputPointer primaryPointer = GetPrimaryPointer(pointers);
		if (primaryPointer != null) {
			GameObject objectPressedOn;
			if (GetObjectFromPointer(primaryPointer, out objectPressedOn)) {
				TowerBehaviour tower;
				if ((tower = objectPressedOn.GetComponent<TowerBehaviour>())) {
					HandlePointerPressedOnTower(tower);
				}
			}
		}
	}

	void HandlePointerPressedOnTower (TowerBehaviour tower) {
		tower.SelectTower();	
	}

	// Tracks any touches and left click down
	public bool HasPointersDown () {
		return Input.touchCount < 0 || Input.GetMouseButton(0);
	}
		
	// Returns true if a pointer was pressed in this frame
	public bool PointerPressed () {
		if (Input.GetMouseButtonDown(0)) {
			return true;
		} else {
			bool pointerPressed = false;
			foreach (Touch touch in Input.touches) {
				pointerPressed |= touch.phase == TouchPhase.Began;
			}
			return pointerPressed;
		}
	}

	public int PointerDownCount () {
		return Input.touchCount + (Input.GetMouseButton(0) ? 1 : 0);
	}

	public InputPointer[] GetPointers () {
		bool mouseIsDown = Input.GetMouseButton(0);
		InputPointer[] pointers = new InputPointer[Input.touchCount + (mouseIsDown ? 1 : 0)];
		int index = 0;
		foreach (Touch touch in Input.touches) {
			pointers[index++] = new InputPointer(touch.position, touch.fingerId, !mouseIsDown && touch.fingerId == 0);
		}
		if (mouseIsDown) {
			pointers[index] = GetMousePointer();
		}
		return pointers;
	}

	// Returns null if there is no primary pointer (or no touches down)
	// Primary pointer with touches is first touch down
	public InputPointer GetPrimaryPointer (InputPointer[] pointers) {
		if (Input.GetMouseButton(0)) {
			return GetMousePointer();
		} else {
			foreach (InputPointer pointer in pointers) {
				if (pointer.IsPrimaryPointer) {
					return pointer;
				}
			}
			return null;
		}
	}

	InputPointer GetMousePointer () {
		return new InputPointer(Input.mousePosition, MOUSE_ID, true);
	}

	public bool GetObjectFromPointer (InputPointer pointer, out GameObject hitObject) {
		RaycastHit hit;
		if (Physics.Raycast(GetPointerRaycastPosition(pointer), Vector3.down, out hit)) {
			hitObject = hit.collider.gameObject;
			return true;
		} else {
			hitObject = null;
			return false;
		}
	}

	Vector3 GetPointerRaycastPosition (InputPointer pointer) {
		Vector3 raycastPosition = pointer.Position;
		raycastPosition.z = raycastPosition.z - Camera.main.transform.position.z;
		raycastPosition = Camera.main.ScreenToWorldPoint(raycastPosition);
		return raycastPosition;
	}


	public GameObject[] GetObjectsHitByPointers (InputPointer[] pointers) {
		List<GameObject> hitObjects = new List<GameObject>();
		foreach (InputPointer pointer in pointers) {
			GameObject hitObject;
			if (GetObjectFromPointer(pointer, out hitObject)) {
				hitObjects.Add(hitObject);
			}
		}
		return hitObjects.ToArray();
	}


	#region Swiping

	bool isSwiping (InputPointer[] pointers, float swipeTolerance, out InputPointer swipingPointer) {
		if (pointersInPreviousFrame == null || pointersInPreviousFrame.Length == 0) {
			swipingPointer = null;
			return false;
		}

		for (int i = 0; i < pointers.Length; i++) {
			if (pointersInPreviousFrame.Length <= i) {
				break;
			}
			if (pointers[i].ID == pointersInPreviousFrame[i].ID && 
				Vector3.Distance(pointers[i].Position, pointersInPreviousFrame[i].Position) > swipeTolerance) {
				swipingPointer = pointers[i];
				return true;
			}
		}
		swipingPointer = null;
		return false;
	}

	void handleSwipe (InputPointer pointer) {
		if (!isDraggingObject) {
			if (previousSwipingPointer != null && pointer.ID == previousSwipingPointer.ID) {
				Vector3 deltaPosition = pointer.Position - previousSwipingPointer.Position;
				if (Math.Abs(Math.Sign(deltaPosition.x) - Math.Sign(swipeDirection.x)) < 2 && 
					Math.Abs(Math.Sign(deltaPosition.y) - Math.Sign(swipeDirection.y)) < 2) {
					panSpeed += PanAcceleration;
				} else {
					panSpeed = 0;
				}
				swipeDirection = deltaPosition;
				deltaPosition *= -panSpeed;
				camera.Pan(new Vector3(deltaPosition.x, 0, deltaPosition.y));
			}
			previousSwipingPointer = pointer;
		}
	}

	#endregion
		
	#region MannBehaviour Methods

	protected override void SetReferences () {
		SingletonUtil.TryInit(ref Instance, this, gameObject);
	}

	protected override void FetchReferences () {
		camera = Camera.main.GetComponent<CameraController>();
	}

	protected override void CleanupReferences () {
		SingletonUtil.TryCleanupSingleton(ref Instance, this);
	}

	protected override void HandleNamedEvent (string eventName) {

	}

	#endregion
}