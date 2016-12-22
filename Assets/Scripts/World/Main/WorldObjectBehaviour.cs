/*
 * Author: Isaiah Mann
 * Description: Superclass for any object found in world
 */

using UnityEngine;
using System.Collections;

public abstract class WorldObjectBehaviour : MannBehaviour {
	protected const string ATTACK_TRIGGER = "Attack";
	[SerializeField]
	protected bool isSprite = false;
	protected WorldController world;
	[SerializeField]
	protected MapLocation Location = new MapLocation(0, 0);

	protected Animator animator;
	protected bool hasAnimator {
		get {
			return animator != null;
		}
	}
		
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

	protected override void SetReferences () {
		base.SetReferences ();
		animator = getMainAnimator();
	}

	protected IEnumerator MoveTo (GameObject destination, float moveTime = 1.0f, EventAction callback = null) {
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
			updateRotation(destination);
			yield return new WaitForEndOfFrame();
		}
		if (transform != null && destination != null) {
			transform.position = destination.transform.position;
		}
		if (callback != null) {
			callback();
		}
	}

	protected virtual void updateRotation (GameObject destination) {
		transform.LookAt(destination.transform);
	}

	protected IEnumerator TimedDestroy (float delayTime = 0.5f) {
		yield return new WaitForSeconds(delayTime);
		Destroy(gameObject);
	}

	protected IEnumerator TimedToggleActive (bool isActive, float delayTime = 0.5f) {
		yield return new WaitForSeconds(delayTime);
		gameObject.SetActive(isActive);
	}

	protected virtual Animator getMainAnimator () {
		return GetComponentInChildren<Animator>();
	}

	protected virtual void sendTriggerToAnimator (string trigger) {
		if (hasAnimator) {
			animator.SetTrigger(trigger);
		}
	}

	public virtual void ToggleColliders (bool areCollidersEnabled) {
		foreach (Collider collider in GetComponentsInChildren<Collider>()) {
			collider.enabled = areCollidersEnabled;
		}
	}

}
