/*
 * Author(s): Isaiah Mann
 * Description: A single cell/square on the map
 */

using UnityEngine;
using System.Collections;

[System.Serializable]
public class MapLocation : IMapLocation {

	public MapLocation (int x, int y) {
		this._x = x;
		this._y = y;
	}

	int _x, _y;

	public void Set (int x, int y) {
		this._x = x;
		this._y = y;
	}

	public int X {
		get {
			return _x;
		}
	}
	public int Y {
		get {
			return _y;
		}
	}

	public int Distance (IMapLocation otherLocation) {
		return Distance(this, otherLocation);
	}

	public static int Distance (IMapLocation loc1, IMapLocation loc2) {
		return (int) Mathf.Sqrt(
			Mathf.Pow(loc1.X - loc2.X, 2) +
			Mathf.Pow(loc1.Y - loc2.Y, 2)
		);
	}
}
