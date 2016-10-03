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
	Renderer meshRenderer;
	SpriteRenderer spriteRenderer;

	void SetTileColor (Color color) {
		meshRenderer.material.color = color;
		spriteRenderer.color = color;
	}

	void Awake () {
		meshRenderer = GetComponent<MeshRenderer>();
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		SetTileColor(standardColor);
	}

	public StaticAgentBehaviour GetCurrentAgent () {
		return containedAgent;
	}

	public void PlaceAgent (StaticAgentBehaviour agent, bool shouldPlaySound = true) {
		if (isIlluminated || agent is CoreOrbBehaviour) {
			containedAgent = agent;
			agent.transform.SetParent(transform);
			agent.transform.localPosition = Vector3.zero;
			agent.SetLocation(this.Location);
			if (agent is IlluminationTowerBehaviour) {
				MapController.Instance.Illuminate(this.Location, (agent as IlluminationTowerBehaviour).IlluminationRadius, shouldPlaySound);
			}
			if (agent is TowerBehaviour) {
				TowerBehaviour tower = agent as TowerBehaviour;
				MapController.Instance.AddActiveTower(tower);
				if (shouldPlaySound) {
					tower.PlayBuildSound();
				}
			}
			agent.ToggleColliders(true);
		} else {
			// TODO: Collect in object pool instead of destroying
			if (shouldPlaySound) {
				EventController.Event(EventType.TowerCannotPlace);
			}
			Destroy(agent.gameObject);
		}
		Unhighlight();
	}

	public void IlluminateSquare (bool shouldPlaySound = true) {
		if (!isIlluminated) {
			isIlluminated = true;
			SetTileColor(illuminatedColor);
			if (shouldPlaySound) {
				EventController.Event(EventType.IlluminationOn);
			}
		}
	}

	public void DelluminateSquare (bool shouldPlaySound = true) {
		if (isIlluminated) {
			isIlluminated = false;
			SetTileColor(standardColor);
			if (shouldPlaySound) {
				EventController.Event(EventType.IlluminationOff);
			}
		}
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
