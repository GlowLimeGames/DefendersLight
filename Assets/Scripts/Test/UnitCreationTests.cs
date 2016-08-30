/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using System.Collections;

public class UnitCreationTests : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AssaultTower tower = new AssaultTower("Lightning", 5, new MapLocation(0, 0), "Hello World", 50, 1, null, null, 50, 2, 2, 2);
		Debug.Log(tower.SerializeAsJSON());
	}
}
