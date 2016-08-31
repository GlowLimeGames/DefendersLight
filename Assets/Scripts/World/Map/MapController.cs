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
		
	MapTileBehaviour SpawnBoardTile (int x, int y) {
		GameObject tile = (GameObject) Instantiate(BoardTilePrefab, GetBoardTileLocation(x, y), Quaternion.identity);
		tile.transform.SetParent(transform);

		MapTileBehaviour tileController = tile.GetComponent<MapTileBehaviour>();
		tileController.SetLocation(x, y);

		return tileController;
	}

	// TODO: Implement Correctly
	Vector3 GetBoardTileLocation (int x, int y) {
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
		
	}

	protected override void CleanupReferences () {

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
