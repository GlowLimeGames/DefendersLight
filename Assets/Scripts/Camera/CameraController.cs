/*
 * Author(s): Isaiah Mann
 * Description: Script for controlling the movement of the camera
 */

using UnityEngine;
using System.Collections;

public class CameraController : Controller {
	public static CameraController Instance;
	public float MinimumZoom = 0.5f;
	public float MaximumZoom = 2.5f;
	public float MaxZoomSpeed = 1f;
	public float ZoomAcceleration = 0.01f;
	[SerializeField]
	float timeToResetPosition = 0.5f;
	[SerializeField]
	float panSpeed = 2f;
	float currentZoom = 1;
	float zoomSpeed;
	float zoomToSizeRatio;

	MapController map;
	new Camera camera;
	Vector3 startingCameraPosition;
	IEnumerator moveCoroutine;

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
	float cameraSize {
		get {
			return currentZoom * zoomToSizeRatio;
		}
	}

	protected override void SetReferences () {
		base.SetReferences();
		Instance = this;
		camera = GetComponent<Camera>();
		zoomToSizeRatio =  camera.orthographicSize * currentZoom;
		startingCameraPosition = Position;
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

	void startLerpCoroutine (Vector3 destination, float time) {
		stopLerpCoroutine();
		moveCoroutine = lerpCamera(destination, time);
		StartCoroutine(moveCoroutine);
	}

	void stopLerpCoroutine () {
		if (moveCoroutine != null) {
			StopCoroutine(moveCoroutine);
		}
	}

	public void ResetCameraPosition(bool animatedLerp = true){
		if (animatedLerp) {
			startLerpCoroutine(startingCameraPosition, timeToResetPosition);
		} else {
			setCameraToStartingPosition();
		}
	}

	void setCameraToStartingPosition () {
		camera.transform.position = startingCameraPosition;
	}

	IEnumerator lerpCamera (Vector3 destination, float time) {
		Vector3 startingPosition = Position;
		float timer = 0;
		while (timer <= time) {
			camera.transform.position = Vector3.Lerp 
				(startingPosition, destination, Easing.Exponential.InOut(timer / time));
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		setCameraToStartingPosition();
	}

	public void Pan (Vector3 panDirection) {
		Vector3 panScaledByZoom = panDirection * currentZoom * panSpeed;
		if (map.InBounds(transform.position + panScaledByZoom)) {
			transform.position += panScaledByZoom;
		}
	}

	public void Zoom (float deltaZoom) {
		zoomSpeed = Mathf.Clamp(zoomSpeed + ZoomAcceleration, 0, MaxZoomSpeed);
		currentZoom = Mathf.Clamp(currentZoom + (deltaZoom * zoomSpeed), MinimumZoom, MaximumZoom);
		camera.orthographicSize = cameraSize;
	}

	public void EndZoom () {
		zoomSpeed = 0;
	}

}
