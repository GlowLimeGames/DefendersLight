/*
 * Author(s): Isaiah Mann
 * Description: Script for controlling the movement of the camera
 */

using UnityEngine;

public class CameraController : Controller {
	public void Pan (Vector3 panDirection) {
		transform.position += panDirection;
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