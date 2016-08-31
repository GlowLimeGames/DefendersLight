/*
 * Author(s): Isaiah Mann
 * Description: Behaviour of a tile on the map (single cell on the game grid)
 */

using UnityEngine;
using System.Collections;

public class MapTileBehaviour : EnvironmentalObjectBehaviour {

	[SerializeField]
	StaticAgentBehaviour containedAgent;
	StaticAgentBehaviour agentToPlace;

	public StaticAgentBehaviour GetCurrentAgent () {
		return containedAgent;
	}

	public void PlaceAgent (StaticAgentBehaviour agent) {
		containedAgent = agent;
		agent.transform.SetParent(transform);
		agent.transform.localPosition = Vector3.zero;
		Unhighlight();
	}

	public void HightlightToPlace (StaticAgentBehaviour agent) {
		GetComponent<Renderer>().material.color = Color.yellow;
		agentToPlace = agent;
	}

	public bool HasAgent () {
		return containedAgent != null;
	}

	public void Unhighlight () {
		GetComponent<Renderer>().material.color = Color.white;
		agentToPlace = null;
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
