/*
 * Author: Isaiah Mann
 * Description: Superclass for any object found in world
 */

using UnityEngine;
using System.Collections;

public abstract class WorldObjectBehaviour : MannBehaviour {
	[SerializeField]
	protected BoardLocation Location;

	public void SetLocation (int x, int y) {
		Location.X = x;
		Location.Y = y;
	}

	public BoardLocation GetLocation () {
		return Location;
	}

}