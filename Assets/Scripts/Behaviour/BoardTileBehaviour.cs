using UnityEngine;
using System.Collections;

public class BoardTileBehaviour : EnvironmentalObjectBehaviour {

	[SerializeField]
	BoardLocation Location;

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

	public void SetLocation (int x, int y) {
		Location.X = x;
		Location.Y = y;
	}

	protected override void FetchReferences () {

    }

    protected override void SetReferences () {

    }

    protected override void HandleNamedEvent (string eventName) {

    }
}
