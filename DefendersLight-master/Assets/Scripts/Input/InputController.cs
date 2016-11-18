/*
 * Author(s): Isaiah Mann
 * Description: Handles player touch input to the game. Single input system to handle both mouse and touch input
 */

using UnityEngine;
using System.Collections.Generic;

public class InputController : MannBehaviour {
	const int MOUSE_ID = int.MaxValue;
	bool inputEnabled = true;
	void Update () {
		if (inputEnabled) {
			HandleInput();
		}
	}

	public void ToggleInputEnabled (bool inputEnabled) {
		this.inputEnabled = inputEnabled;
	}

	void HandleInput () {
		if (HasPointersDown()) {
			HandlePointersDown();
		}
	}


	void HandlePointersDown () {
		if (PointerPressed()) {			
			HandlePointerPressed();
		}
	}

	void HandlePointerPressed () {
		InputPointer primaryPointer = GetPrimaryPointer();
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
	public InputPointer GetPrimaryPointer () {
		if (Input.GetMouseButton(0)) {
			return GetMousePointer();
		} else {
			foreach (InputPointer pointer in GetPointers()) {
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


	public GameObject[] GetObjectsHitByPointers () {
		List<GameObject> hitObjects = new List<GameObject>();
		foreach (InputPointer pointer in GetPointers()) {
			GameObject hitObject;
			if (GetObjectFromPointer(pointer, out hitObject)) {
				hitObjects.Add(hitObject);
			}
		}
		return hitObjects.ToArray();
	}

	protected override void SetReferences () {

	}

	protected override void FetchReferences () {

	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent (string eventName) {

	}
}