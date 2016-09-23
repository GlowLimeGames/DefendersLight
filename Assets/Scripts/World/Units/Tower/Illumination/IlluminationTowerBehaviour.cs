/*
 * Author(s): Isaiah Mann
 * Description: Behaviour of an illumination tower
 */

using UnityEngine;
using System.Collections;

public class IlluminationTowerBehaviour : TowerBehaviour {
	public int IlluminationRadius;

	public override void PlayBuildSound () {
		EventController.Event(EventType.BuildIlluminationTower);
	}
}
