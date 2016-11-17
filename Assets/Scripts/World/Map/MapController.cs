/*
 * Author(s): Isaiah Mann
 * Description: Controls the display and behaviour of the game world
 */

using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MapController : MannBehaviour, IMapController {
	public static MapController Instance;

	WorldController world;

	[SerializeField]
	MapStats Stats;

	[SerializeField]
	GameObject BoardTilePrefab;

	[SerializeField]
	MapTileBehaviour[,] Board;
	Bounds mapBounds;
	float zBound = 10f;
	List<MapTileBehaviour> highlightedTiles = new List<MapTileBehaviour>();

	void GenerateBoard (WorldController world) {
		Board = new MapTileBehaviour[Stats.Width,Stats.Height];
		for (int x = 0; x < Stats.Width; x++) {
			for (int y = 0; y < Stats.Height; y++) {
				Board[x, y] = SpawnBoardTile(x, y);
				Board[x, y].Setup(this, world, new MapLocation(x, y), getQuadrant(x, y));
			}
		}
		mapBounds = new Bounds(GetCenterTile().GetWorldPosition(), new Vector3(Stats.Width * Stats.TileSize, zBound, Stats.Height * Stats.TileSize));
	}

	public void HighlightValidBuildTiles () {
		foreach (MapTileBehaviour tile in Board) {
			if (tile.CanPlaceTower()) {
				tile.SetToValidBuildColor();
				highlightedTiles.Add(tile);
			}
		}
	}

	public void UnhighlightValidBuildsTiles () {
		foreach (MapTileBehaviour tile in highlightedTiles) {
			tile.SetToIlluminatedColor();
		}
		highlightedTiles.Clear();
	}

	public MapTileBehaviour GetCenterTile () {
		if (Board != null) {
			return Board[Stats.Width/2, Stats.Height/2];
		} else {
			return null;
		}
	}

	public MapTileBehaviour GetTileFromLocation (MapLocation location) {
		if (inBounds(location)) {
			return Board[location.X, location.Y];
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

	bool inBounds (MapLocation location) {
		return inBounds(location.X, location.Y);
	}
		
	bool inBounds (int x, int y) {
		return IntUtil.InRange(x, Stats.Width) && IntUtil.InRange(y, Stats.Height);
	}

	public bool InBounds (Vector3 worldPosition) {
		return mapBounds.Contains(worldPosition);
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
		return new Vector3((x - Stats.Width/2) * Stats.TileSize, 0, (y - Stats.Height/2) * Stats.TileSize);
	}

	MapQuadrant getQuadrant (int x, int y) {
		return getQuadrant(new MapLocation(x, y));
	}

	MapQuadrant getQuadrant (MapLocation location) {
		if (location.X < Stats.Width / 2) {
			if (location.Y > Stats.Height / 2) {
				return MapQuadrant.NorthWest;
			} else {
				return MapQuadrant.SouthWest;
			}
		} else {
			if (location.Y > Stats.Height / 2) {
				return MapQuadrant.NorthEast;
			} else {
				return MapQuadrant.SouthEast;
			}
		}
	}

	MapTileBehaviour[] getMapEdges () {
		int tileOverlap = 4;
		MapTileBehaviour[] edges = new MapTileBehaviour[Stats.Width * 2 + Stats.Height * 2 - tileOverlap];
		for (int x = 0; x < Stats.Width; x++) {
			edges[x] = Board[x, 0];
			edges[x + Stats.Width] = Board[x, Stats.Height - 1];
		}
		int offset = Stats.Width * 2 - 1;
		for (int y = 1; y < Stats.Height - 1; y++) {
			edges[y + offset] = Board[0, y];
			edges[y + offset + Stats.Height - 2] = Board[Stats.Width - 1, y];
		}
		return edges;
	}

	public MapTileBehaviour[] GetQudrantEdges (MapQuadrant quadrant) {
		List<MapTileBehaviour> edges = new List<MapTileBehaviour>();
		edges.AddRange(getMapEdges());
		List<MapTileBehaviour> edgeList = edges.FindAll(tile => tile.Quadrant == quadrant);
		if (edgeList != null) {
			return edgeList.ToArray();
		} else {
			return new MapTileBehaviour[0];
		}
	}
		
	protected override void FetchReferences () {
		if (SingletonUtil.IsSingleton(Instance, this)) {
			world = WorldController.Instance;
			GenerateBoard(world);
		}
	}

	protected override void SetReferences () {
		if (SingletonUtil.TryInit(ref Instance, this, gameObject)) {
		}
	}

	protected override void HandleNamedEvent (string eventName) {
		if (eventName == EventType.TowerDestroyed || eventName == EventType.TowerSold) {
			RefreshIlluminations();
		}
	}

	protected override void CleanupReferences () {
		SingletonUtil.TryCleanupSingleton(ref Instance, this);
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
