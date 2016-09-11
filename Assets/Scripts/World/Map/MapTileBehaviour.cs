/*
 * Author(s): Isaiah Mann
 * Description: Behaviour of a tile on the map (single cell on the game grid)
 */

using UnityEngine;
using System.Collections;

public class MapTileBehaviour : EnvironmentalObjectBehaviour {
	[SerializeField]
	StaticAgentBehaviour containedAgent;
	Color hightlightColor = Color.green;
	Color cannotBuildColor = Color.red;
	Color illuminatedColor = Color.yellow;
	Color standardColor = Color.black;
	bool isIlluminated;

	void SetTileColor (Color color) {
		GetComponent<Renderer>().material.color = color;
	}

	void Awake () {
		SetTileColor(standardColor);
	}

	public StaticAgentBehaviour GetCurrentAgent () {
		return containedAgent;
	}

	public void PlaceAgent (StaticAgentBehaviour agent) {
		if (isIlluminated || agent is CoreOrbBehaviour) {
			containedAgent = agent;
			agent.transform.SetParent(transform);
			agent.transform.localPosition = Vector3.zero;
			agent.SetLocation(this.Location);
			if (agent is IlluminationTowerBehaviour) {
				MapController.Instance.Illuminate(this.Location, (agent as IlluminationTowerBehaviour).IlluminationRadius);
			}
			agent.ToggleColliders(true);
		} else {
			// TODO: Collect in object pool instead of destroying
			Destroy(agent.gameObject);
		}
		Unhighlight();
	}

	public void IlluminateSquare () {
		isIlluminated = true;
		SetTileColor(illuminatedColor);
	}

	public void DelluminateSquare () {
		isIlluminated = false;
		SetTileColor(standardColor);
	}

	public void HightlightToPlace (StaticAgentBehaviour agent) {
		if (isIlluminated) {
			SetTileColor(hightlightColor);
		} else {
			SetTileColor(cannotBuildColor);
		}
	}

	public bool HasAgent () {
		return containedAgent != null;
	}

	public void Unhighlight () {
		if (isIlluminated) {
			SetTileColor(illuminatedColor);
		} else {
			SetTileColor(standardColor);
		}
	}

	public void RemoveAgent () {

	}

	protected override void FetchReferences () {

    }

    protected override void SetReferences () {

    }

	protected override void CleanupReferences () {

	}
    protected override void HandleNamedEvent (string eventName) {

    }
}
