/*
 * Author(s): Isaiah Mann
 * Description: A single cell/square on the map
 */

using UnityEngine;
using System.Collections;

[System.Serializable]
public class MapLocation : IMapLocation {

	// Adapapted from http://stackoverflow.com/questions/1920116/default-value-for-user-defined-class-in-c-sharp
	public static readonly MapLocation Default = new MapLocation(0, 0) {};

	public MapLocation (int x, int y) {
		this.X = x;
		this.Y = y;
	}

	public int X;
	public int Y;

	public void Set (int x, int y) {
		this.X = x;
		this.Y = y;
	}

	public void Set (IMapLocation location) {
		this.X = location.IX;
		this.Y = location.IY;
	}

	public int IX {
		get {
			return X;
		}
	}
	public int IY {
		get {
			return Y;
		}
	}

	public int Distance (IMapLocation otherLocation) {
		return Distance(this, otherLocation);
	}

	public static int Distance (IMapLocation loc1, IMapLocation loc2) {
		return (int) Mathf.Sqrt(
			Mathf.Pow(loc1.IX - loc2.IX, 2) +
			Mathf.Pow(loc1.IY - loc2.IY, 2)
		);
	}

	public override string ToString () {
		return string.Format ("(X={0}, Y={1})", X, Y);
	}

	public MapLocation Translate (int x, int y) {
		return new MapLocation(this.X + x, this.Y + y);
	}
}
