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

	public virtual void NavigatePath (Queue<MapTileBehaviour> path, float timePerStep) {
		if (gameObject.activeSelf) {
			haltMovementCoroutine();
			movementCoroutine = runPathNavigation(path, timePerStep);
			StartCoroutine(movementCoroutine);
		}
	}

	protected virtual void haltMovementCoroutine () {
		if (this && movementCoroutine != null) {
			StopCoroutine(movementCoroutine);
		}
	}

	protected virtual void updateCurrentLocation (MapTileBehaviour currentTile) {
		this.currentTile = currentTile;
		transform.position = currentTile.GetWorldPosition() + offset;
	}

	IEnumerator runPathNavigation (Queue<MapTileBehaviour> path, float timePerStep) {
		while (path.Count > 0) {
			MapTileBehaviour currentTile = path.Dequeue();
			Vector3 previousLocation = transform.position;
			Vector3 targetLocation = currentTile.GetWorldPosition() + offset;
			if (!isSprite) {
				transform.rotation = Quaternion.LookRotation(targetLocation - previousLocation);
			}
			float timer = 0;
			while (timer <= timePerStep) {
				transform.position = Vector3.Lerp(previousLocation, targetLocation, timer / timePerStep);
				yield return new WaitForEndOfFrame();
				timer += Time.deltaTime;
			}
			updateCurrentLocation(currentTile);
			yield return new WaitForEndOfFrame();
		}
	}
}
