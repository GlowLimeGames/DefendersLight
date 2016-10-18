/*
 * Author(s): Isaiah Mann
 * Description: Denotes an enemy spawn point
 */

using UnityEngine;

public class EnemySpawnPoint : MannBehaviour {
	public Direction Location;

	public MapLocation MapLocation {
		get {
			if (currentSpawnPoint) {
				return currentSpawnPoint.GetLocation();
			} else {
				return null;
			}
		}
	}
	public MapTileBehaviour Tile {
		get {
			return currentSpawnPoint;
		}
	}
	MapTileBehaviour currentSpawnPoint;
	MapTileBehaviour[] currentPath;
	MapQuadrant quadrant;

	public Vector3 GetPosition () {
		return currentSpawnPoint.GetWorldPosition() + Vector3.up;
	}

	public void Setup (MapQuadrant quadrant) {
		this.quadrant = quadrant;
	}

	public void ChooseStartingTile () {
		MapTileBehaviour[] tiles = MapController.Instance.GetQudrantEdges(quadrant);
		currentSpawnPoint = tiles[Random.Range(0, tiles.Length)];
	}

	public void SetPath (MapTileBehaviour[] path) {
		this.currentPath = path;
		foreach (MapTileBehaviour tile in path) {
			tile.Highlight();
		}
	}

	public void SpawnEnemies (EnemyBehaviour[] enemies) {
		foreach (EnemyBehaviour enemy in enemies) {
			currentSpawnPoint.PositionMobileAgent(enemy);
		}
	}
		
	protected override void SetReferences () {
		// NOTHING
	}

	protected override void FetchReferences () {
		// NOTHING
	}


	protected override void HandleNamedEvent (string eventName) {
		// NOTHING
	}

	protected override void CleanupReferences () {
		// NOTHING
	}
}
