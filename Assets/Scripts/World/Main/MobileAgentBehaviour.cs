/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a world objects that can move around the map
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MobileAgentBehaviour : ActiveObjectBehaviour {
	protected bool isMoving;
	protected IEnumerator movementCoroutine;
	protected MapTileBehaviour currentTile;
    public abstract void MoveTo(MapLocation location);
	Vector3 offset;

	public void SetOffset (Vector3 offset) {
		this.offset = offset;
	}

	public void NavigatePath (Queue<MapTileBehaviour> path, float timePerStep) {
		haltMovementCoroutine();
		movementCoroutine = runPathNavigation(path, timePerStep);
		StartCoroutine(movementCoroutine);
	}

	protected void haltMovementCoroutine () {
		if (this && movementCoroutine != null) {
			StopCoroutine(movementCoroutine);
		}
	}

	protected virtual void updateCurrentLocation (MapTileBehaviour currentTile) {
		this.currentTile = currentTile;
		transform.position = currentTile.GetWorldPosition() + offset;
	}

	IEnumerator runPathNavigation (Queue<MapTileBehaviour> path, float timePerStep) {
		Vector3 previousLocation = transform.position;
		while (path.Count > 0) {
			float timer = 0;
			MapTileBehaviour currentTile = path.Dequeue();
			while (timer <= timePerStep) {
				transform.position = Vector3.Lerp(transform.position, currentTile.GetWorldPosition() + offset, timer / timePerStep);
				timer += Time.deltaTime;
				yield return new WaitForEndOfFrame();
			}
			updateCurrentLocation(currentTile);
		}
	}
}
