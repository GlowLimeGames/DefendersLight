/*
 * Author(s): Isaiah Mann
 * Description: Script for controlling the movement of the camera
 */

using UnityEngine;

public class CameraController : Controller {
	MapController map;

	public void Pan (Vector3 panDirection) {
		if (map.InBounds(transform.position + panDirection)) {
			transform.position += panDirection;
		}
	}

	protected override void SetReferences () {

	}

	protected override void FetchReferences () {
		map = MapController.Instance;
	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent (string eventName) {

	}
}