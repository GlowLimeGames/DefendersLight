using UnityEngine;
using System.Collections;

[System.Serializable]
public class BoardLocation {

	public int X, Y;

	public static int Distance (BoardLocation loc1, BoardLocation loc2) {
		return (int) Mathf.Sqrt(
			Mathf.Pow(loc1.X - loc2.X, 2) +
			Mathf.Pow(loc1.Y - loc2.Y, 2)
		);
	}
}
