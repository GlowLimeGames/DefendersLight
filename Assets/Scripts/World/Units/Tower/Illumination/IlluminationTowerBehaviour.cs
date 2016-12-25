/*
 * Author(s): Isaiah Mann
 * Description: Behaviour of an illumination tower
 */

public class IlluminationTowerBehaviour : TowerBehaviour {
	public override void CallBuildEvent () {
		EventController.Event(EventType.BuildIlluminationTower);
		EventController.Event(EventType.IlluminationOn);
	}

	public override void CallDestroyEvent () {
		base.CallDestroyEvent();
		EventController.Event(EventType.IlluminationOff);
	}
}
