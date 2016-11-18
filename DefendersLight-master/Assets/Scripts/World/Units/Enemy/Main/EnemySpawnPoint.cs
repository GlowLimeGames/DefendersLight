/*
 * Author(s): Isaiah Mann
 * Description: Denotes an enemy spawn point
 */

using UnityEngine;

public class EnemySpawnPoint : MannBehaviour {
	public static System.Collections.Generic.Dictionary<Direction, EnemySpawnPoint> SpawnPoints = new System.Collections.Generic.Dictionary<Direction, EnemySpawnPoint>();

	public Direction Location;

	public static Vector3 GetPosition (Direction spawnLocation) {
		EnemySpawnPoint spawnPoint;
		if (SpawnPoints.TryGetValue(spawnLocation, out spawnPoint)) {
			return spawnPoint.GetPosition();
		} else {
			Debug.LogWarningFormat("Dictionary does not contains direction {0}. Returning zero vector", spawnLocation);
			return Vector3.zero;
		}
	}

	public Vector3 GetPosition () {
		return transform.position;
	}

	protected override void FetchReferences () {
		// NOTHING
	}

	protected override void SetReferences () {
		if (SpawnPoints.ContainsKey(Location)) {
			Debug.LogWarningFormat("Dictionary already contains direction {0}. Spawn Point {1} will not be available", Location, gameObject);
		} else {
			SpawnPoints.Add(Location, this);
		}
	}

	protected override void HandleNamedEvent (string eventName) {
		// NOTHING
	}

	protected override void CleanupReferences () {
		if (SpawnPoints.ContainsValue(this) && SpawnPoints.ContainsKey(Location)) {
			SpawnPoints.Remove(Location);
		}
	}
}
