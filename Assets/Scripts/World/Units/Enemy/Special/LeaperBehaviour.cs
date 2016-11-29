/*
 * Author(s): Isaiah Mann
 * Description: Special behaviour for the leaper enemy (which can jump over towers)
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LeaperBehaviour : EnemyBehaviour {
	MapTileBehaviour jumpDestinationTile;
	[SerializeField]
	float jumpHeight = 5; // In world units
	[SerializeField]
	float leapTime = 1; // In Seconds
	[SerializeField]
	bool simulatePerspective = true; // Simulates perspective when in orthographic mode (no indication of relative distance from camera)
	QuadraticEquation jumpHeightEquation;
	bool _isLeaping;
	public bool IsLeaping {
		get {
			return _isLeaping;
		}
	}

	protected override void SetReferences () {
		base.SetReferences ();
		// Creates an upside down quadratic
		jumpHeightEquation = new QuadraticEquation(2, jumpHeight, -0.5f, -4 * jumpHeight);
	}

	// The leaper can spend an attack to jump over a tower (which it will default to if it can
	public override void Attack (ActiveObjectBehaviour target, int damage) {
		if (IsLeaping) {
			return;
		}

		if (shouldJumpInsteadOfAttacking(target, out jumpDestinationTile)) {
			handleJumpOverTower(target, jumpDestinationTile);
		} else {
			base.Attack (target, damage);
		}
	}

	bool shouldJumpInsteadOfAttacking (ActiveObjectBehaviour target, out MapTileBehaviour destinationTile) {
		// Don't jump over the core orb
		if (target is TowerBehaviour && !(target is CoreOrbBehaviour)) {
			TowerBehaviour tower = target as TowerBehaviour;
			MapTileBehaviour towerTile = tower.ITile;
			Direction directionOfTile = currentTile.GetDirection(towerTile);
			MapTileBehaviour targetTile = towerTile.TileFromDirection(directionOfTile);
			if (targetTile && !targetTile.HasAgent()) {
				destinationTile = targetTile;
				return true;
			} else {
				destinationTile = null;
				return false;
			}
		} else {
			destinationTile = null;
			return false;
		}
	}

	public override void ResetStats () {
		base.ResetStats ();
		_isLeaping = false;
	}

	void handleJumpOverTower (ActiveObjectBehaviour target, MapTileBehaviour destinationTile) {
		_isLeaping = true;
		StartCoroutine(leap(destinationTile, leapTime));
	}


	void handleJumpEnded (MapTileBehaviour destinationTile) {
		_isLeaping = false;
		this.currentTile = destinationTile;
		List<MapTileBehaviour> editablePath = path.ToList();
		editablePath.Insert(0, destinationTile);
		this.path = new Queue<MapTileBehaviour>(editablePath);
		resumeMoving();
	}
		
	IEnumerator leap (MapTileBehaviour destinationTile, float time) {
		Vector3 targetLocation = destinationTile.GetWorldPosition();
		Vector3 startingPosition = transform.position;
		Vector3 actualScale = transform.localScale;
		float timer = 0;
		while (timer <= time) {
			float progress = timer / time;
			float height = jumpHeightEquation.Calculate(progress);
			transform.position = Vector3.Lerp(startingPosition, targetLocation, progress) + Vector3.up * height;
			if (simulatePerspective) {
				transform.localScale = actualScale * (1 + height);
			}
			yield return new WaitForEndOfFrame();
			timer += Time.deltaTime;
		}
		transform.position = targetLocation;
		transform.localScale = actualScale;
		handleJumpEnded(destinationTile);
	}
}
