/*
 * Author: Isaiah Mann
 * Description: Superclass for any object found in world
 */

using UnityEngine;
using System.Collections;

public abstract class WorldObjectBehaviour : MannBehaviour {
	protected WorldController world;
	[SerializeField]
	protected MapLocation Location = new MapLocation(0, 0);

	protected override void FetchReferences () {
		world = WorldController.Instance;
	}

	public void SetLocation (int x, int y) {
		Location.Set(x, y);
	}

	public void SetLocation (MapLocation location) {
		this.Location.Set(location);
	}

	public MapLocation GetLocation () {
		return Location;
	}

	protected IEnumerator MoveTo (GameObject destination, float moveTime = 1.0f) {
		float timer = 0;

		Vector3 start = transform.position;

		while (timer <= moveTime) {
			timer += Time.deltaTime;

			if (destination == null) {
				yield break;
			}

			transform.position = Vector3.Lerp (
				start,
				destination.transform.position,
				timer/moveTime
			);

			yield return new WaitForEndOfFrame();
		}
		if (transform != null && destination != null) {
			transform.position = destination.transform.position;
		}
	}

	protected IEnumerator TimedDestroy (float delayTime = 0.5f) {
		yield return new WaitForSeconds(delayTime);
		Destroy(gameObject);
	}

	protected IEnumerator TimedToggleActive (bool isActive, float delayTime = 0.5f) {
		yield return new WaitForSeconds(delayTime);
		gameObject.SetActive(isActive);
	}

	public virtual void ToggleColliders (bool areCollidersEnabled) {
		foreach (Collider collider in GetComponentsInChildren<Collider>()) {
			collider.enabled = areCollidersEnabled;
		}
	}

}
