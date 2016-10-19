/*
 * Author(s): Isaiah Mann
 * Description: Behaviour of a tile on the map (single cell on the game grid)
 */

using UnityEngine;

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
	[SerializeField]
	public MapQuadrant Quadrant {private set; get;}
	MapController controller;
	public int X {
		get {
			return Location.X;
		}
	}
	public int Y {
		get {
			return Location.Y;
		}
	}
	public MapTileBehaviour North {
		get {
			return controller.GetTileFromLocation(Location.Translate(0, 1));
		}
	}
	public MapTileBehaviour East {
		get {
			return controller.GetTileFromLocation(Location.Translate(1, 0));
		}
	}
	public MapTileBehaviour South {
		get {
			return controller.GetTileFromLocation(Location.Translate(0, -1));
		}
	}
	public MapTileBehaviour West {
		get {
			return controller.GetTileFromLocation(Location.Translate(-1, 0));
		}
	}

	public Vector3 GetWorldPosition () {
		return transform.position + Vector3.up;
	}

	public MapTileBehaviour TileFromDirection (Direction direction) {
		switch (direction) {
		case Direction.North:
			return North;
		case Direction.East:
			return East;
		case Direction.South:
			return South;
		case Direction.West:
			return West;
		case Direction.NorthEast:
			return controller.GetTileFromLocation(Location.Translate(1, 1));
		case Direction.NorthWest:
			return controller.GetTileFromLocation(Location.Translate(-1, 1));
		case Direction.SouthEast:
			return controller.GetTileFromLocation(Location.Translate(1, -1));
		case Direction.SouthWest:
			return controller.GetTileFromLocation(Location.Translate(-1, -1));
		case Direction.Zero:
			return this;
		default:
			return null;
		}
			
	}

	public Direction GetDirection (MapTileBehaviour toTile) {
		return DirectionUtil.GetDirection(Location.Difference(toTile.Location));
	}

	public bool LinearPathTo (MapTileBehaviour toTile) {
		return X == toTile.X ^ Y == toTile.Y;
	}

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

	public void Setup (MapController controller, MapLocation location, MapQuadrant quadrant) {
		this.controller = controller;
		this.Quadrant = quadrant;
	}

	public void Highlight () {
		SetTileColor(Color.blue);
	}
		
	public void PlaceStaticAgent (StaticAgentBehaviour agent, bool shouldPlaySound = true) {
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

	public void PositionMobileAgent (MobileAgentBehaviour agent) {

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

	public float GetDistance (Vector3 fromWorldPosition) {
		return Vector3.Distance(transform.position, fromWorldPosition);
	}

	public override string ToString () {
		return string.Format ("[MapTileBehaviour: ({0}, {1})]", Location.X, Location.Y);
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
