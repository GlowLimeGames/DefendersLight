/*
 * Author: Isaiah Mann
 * Description: Superclass for any object found in world
 */

using UnityEngine;
using System.Collections;

public abstract class WorldObjectBehaviour : MannBehaviour {
	[SerializeField]
	protected MapLocation Location = new MapLocation(0, 0);

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

		transform.position = destination.transform.position;
	}

}