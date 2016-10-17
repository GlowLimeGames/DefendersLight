/*
 * Author(s): Isaiah Mann
 * Description: Controls the display and behaviour of the game world
 */

using UnityEngine;
using System.Collections;

public class MapController : MannBehaviour, IMapController {
	public static MapController Instance;

	[SerializeField]
	MapStats Stats;

	[SerializeField]
	GameObject BoardTilePrefab;

	[SerializeField]
	MapTileBehaviour[,] Board;

	void GenerateBoard () {
		Board = new MapTileBehaviour[Stats.Width,Stats.Height];
		for (int x = 0; x < Stats.Width; x++) {
			for (int y = 0; y < Stats.Height; y++) {
				Board[x, y] = SpawnBoardTile(x, y);
			}
		}
	}

	public MapTileBehaviour GetCenterTile () {
		if (Board != null) {
			return Board[Stats.Width/2, Stats.Height/2];
		} else {
			return null;
		}
	}

	public MapTileBehaviour GetTileFromPosition (Vector3 position) {
		int x = (int) position.x + Stats.Width/2;
		int y = (int) position.y + Stats.Height/2;
		if (IntUtil.InRange(x, Board.GetLength(0)) && IntUtil.InRange(y, Board.GetLength(1))) {
			return Board[x, y];
		} else {
			return null;
		}

	}

	public void AddActiveTower (TowerBehaviour tower) {
		WorldController.Instance.AddActiveTower(tower);
	}

	public void Illuminate (MapLocation location, int radius, bool shouldPlaySound = true) {
		int diameter = radius * 2;
		int zeroOffset = 1;
		int startX = Mathf.Clamp(location.X - radius, 0, Stats.Width);
		int startY = Mathf.Clamp(location.Y - radius, 0, Stats.Height);
		for (int x = startX; x < startX + diameter + zeroOffset && x < Stats.Width; x++) {
			for (int y = startY; y < startY + diameter + zeroOffset && y < Stats.Height; y++) {
				Board[x, y].IlluminateSquare(shouldPlaySound);
			}
		}
	}

	public void DeilluminateAll () {
		for (int x = 0; x < Stats.Width; x++) {
			for (int y = 0; y < Stats.Height; y++) {
				Board[x, y].DelluminateSquare();
			}
		}
	}

	public void RefreshIlluminations () {
		DeilluminateAll();
		WorldController.Instance.RefreshIlluminations();
	}

	public MapTileBehaviour GetClosest (Vector3 toPosition) {
		MapTileBehaviour currentClosest = null;
		float currentDistance = float.MaxValue;
		foreach (MapTileBehaviour tile in Board) {
			if (!currentClosest || currentClosest.GetDistance(toPosition) < currentDistance) {
				currentClosest = tile;
			}
		}
		return currentClosest;
	}

	MapTileBehaviour SpawnBoardTile (int x, int y) {
		GameObject tile = (GameObject) Instantiate(BoardTilePrefab, GetBoardTileLocation(x, y), Quaternion.identity);
		tile.transform.SetParent(transform);
		MapTileBehaviour tileController = tile.GetComponent<MapTileBehaviour>();
		tileController.SetLocation(x, y);
		return tileController;
	}
		
	Vector3 GetBoardTileLocation (int x, int y) {
		// TODO: Implement Correctly
		return new Vector3(x - Stats.Width/2, 0, y - Stats.Height/2);
	}

	protected override void FetchReferences () {
		
	}

	protected override void SetReferences () {
		if (SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			GenerateBoard();
		}
	}

	protected override void HandleNamedEvent (string eventName) {
		if (eventName == EventType.TowerDestroyed) {
			RefreshIlluminations();
		}
	}

	protected override void CleanupReferences () {
		Instance = null;
	}

	public void Place(IWorldObject element, IMapLocation location) {
		throw new System.NotImplementedException();
	}

	public void MoveTo(IWorldObject element, IMapLocation location) {
		throw new System.NotImplementedException();
	}

	public bool TryGetPath(IWorldObject element, IMapLocation destination, out IMapPath path) {
		throw new System.NotImplementedException();
	}

	public IWorldObject ObjectAt (IMapLocation location) {
		throw new System.NotImplementedException();
	}
		
	#region Input Handling
	public void HandleZoom (float zoomFactor) {
		throw new System.NotImplementedException();
	}

	public void HandlePan (Vector2 panDirection) {
		throw new System.NotImplementedException();
	}
	#endregion

}
