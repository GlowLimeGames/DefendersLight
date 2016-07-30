/*
 * Author(s): Isaiah Mann
 * Description: Behaviour of a tile on the map (single cell on the game grid)
 */

using UnityEngine;
using System.Collections;

public class MapTileBehaviour : EnvironmentalObjectBehaviour {

	[SerializeField]
	StaticAgentBehaviour containedAgent;

	public StaticAgentBehaviour GetCurrentAgent () {
		return containedAgent;
	}

	public void PlaceAgent (StaticAgentBehaviour agent) {
		containedAgent = agent;
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
