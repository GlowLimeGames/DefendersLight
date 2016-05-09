using UnityEngine;
using System.Collections;

public class BoardController : MannBehaviour {
	[SerializeField]
	BoardStats Stats;

	[SerializeField]
	GameObject BoardTilePrefab;

	[SerializeField]
	BoardTileBehaviour[,] Board;

	void GenerateBoard () {
		Board = new BoardTileBehaviour[Stats.Width,Stats.Height];
		for (int x = 0; x < Stats.Width; x++) {
			for (int y = 0; y < Stats.Height; y++) {
				Board[x, y] = SpawnBoardTile(x, y);
			}
		}

	}

	BoardTileBehaviour SpawnBoardTile (int x, int y) {
		GameObject tile = (GameObject) Instantiate(BoardTilePrefab, GetBoardTileLocation(x, y), Quaternion.identity);
		tile.transform.SetParent(transform);

		BoardTileBehaviour tileController = tile.GetComponent<BoardTileBehaviour>();
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
		GenerateBoard();
	}

	protected override void HandleNamedEvent (string eventName) {
		
	}

	protected override void CleanupReferences () {

	}
}
