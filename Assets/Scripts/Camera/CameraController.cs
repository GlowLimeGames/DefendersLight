/*
 * Author(s): Isaiah Mann
 * Description: Script for controlling the movement of the camera
 */

using UnityEngine;

public class CameraController : Controller {
	public static CameraController Instance;
	public float MinimumZoom = 0.5f;
	public float MaximumZoom = 2.5f;
	public float MaxZoomSpeed = 1f;
	public float ZoomAcceleration = 0.01f;
	float currentZoom = 1;
	float zoomSpeed;
	float zoomToSizeRatio;
	MapController map;
	new Camera camera;
	public Vector3 Position {
		get {
			return transform.position;
		}
	}
	public Vector3 ICameraDirection {
		get {
			float angle = ICameraAngleRad;
			return new Vector3(0, -Mathf.Cos(angle), Mathf.Sin(angle)); 
		}
	}

	public float ICameraAngleRad {
		get {
			return (90 - transform.rotation.eulerAngles.x) * Mathf.Deg2Rad;
		}
	}

	public void Pan (Vector3 panDirection) {
		if (map.InBounds(transform.position + panDirection)) {
			transform.position += panDirection;
		}
	}

	public void Zoom (float deltaZoom) {
		zoomSpeed = Mathf.Clamp(zoomSpeed + ZoomAcceleration, 0, MaxZoomSpeed);
		currentZoom = Mathf.Clamp(currentZoom + (deltaZoom * zoomSpeed), MinimumZoom, MaximumZoom);
		camera.orthographicSize = currentZoom * zoomToSizeRatio;
	}

	public void EndZoom () {
		zoomSpeed = 0;
	}


	protected override void SetReferences () {
		Instance = this;
		camera = GetComponent<Camera>();
		zoomToSizeRatio =  camera.orthographicSize * currentZoom;
	}

	protected override void FetchReferences () {
		base.FetchReferences();
		map = MapController.Instance;
	}
		
	protected override void CleanupReferences () {
		base.CleanupReferences();
		if (Instance == this) {
			Instance = null;
		}
	}

	protected override void HandleNamedEvent (string eventName) {
		// NOTHING
	}
}