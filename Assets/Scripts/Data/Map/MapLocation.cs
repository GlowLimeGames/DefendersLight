/*
 * Author(s): Isaiah Mann
 * Description: A single cell/square on the map
 */

using UnityEngine;
using System.Collections;

[System.Serializable]
public class MapLocation : IMapLocation {

	int x, y;

	public void Set (int x, int y) {
		this.x = x;
		this.y = y;
	}

	public int GetX () {
		return this.x;
	}

	public int GetY () {
		return this.y;
	}

	public int Distance (IMapLocation otherLocation) {
		return Distance(this, otherLocation);
	}

	public static int Distance (IMapLocation loc1, IMapLocation loc2) {
		return (int) Mathf.Sqrt(
			Mathf.Pow(loc1.GetX() - loc2.GetX(), 2) +
			Mathf.Pow(loc1.GetY() - loc2.GetY(), 2)
		);
	}
}
