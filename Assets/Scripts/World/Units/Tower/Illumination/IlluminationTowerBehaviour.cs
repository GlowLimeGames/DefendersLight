/*
 * Author(s): Isaiah Mann
 * Description: Behaviour of an illumination tower
 */

using UnityEngine;
using System.Collections;

public class IlluminationTowerBehaviour : TowerBehaviour {
	public override void CallBuildEvent () {
		EventController.Event(EventType.BuildIlluminationTower);
	}
}
