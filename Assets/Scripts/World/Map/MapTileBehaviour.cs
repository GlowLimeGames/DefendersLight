/*
 * Author(s): Isaiah Mann
 * Description: Behaviour of a tile on the map (single cell on the game grid)
 */

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MapTileBehaviour : EnvironmentalObjectBehaviour {
	WorldController world;
	[SerializeField]
	StaticAgentBehaviour containedAgent;
	const float TOWER_HEIGHT_OFFSET = 1;
	static Color hightlightColor = Color.green;
	static Color validBuildColor = Color.Lerp(Color.green, Color.yellow, 0.75f);
	static Color cannotBuildColor = Color.red;
	static Color illuminatedColor = Color.yellow;
	static Color standardColor = Color.black;
	static Color[] tempColors = new Color[]{hightlightColor, cannotBuildColor};
	HashSet<ILightSource> lightSources = new HashSet<ILightSource>();
	Color previousColor;
	public bool IIsIlluminated {
		get {
			return isIlluminated;
		}
	}
	int _illuminationSourceCount = 0;
	public int IllumninationCount {
		get {
			return _illuminationSourceCount;
		}
	}
	bool isIlluminated {
		get {
			return IllumninationCount > NONE_VALUE;
		}
	}
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

	public void SetToValidBuildColor () {
		SetTileColor(validBuildColor);
	}

	public void SetToIlluminatedColor () {
		SetTileColor(illuminatedColor);
	}

	void SetTileColor (Color color) {
		// Only track permanent colors (not highlighting colors)
		if (!Array.Exists(tempColors, instanceClor => instanceClor == spriteRenderer.color)) {
			previousColor = spriteRenderer.color;
		}
		spriteRenderer.color = color;
	}

	void setToPreviousColor() {
		SetTileColor(previousColor);
	}

	void Awake () {
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		SetTileColor(standardColor);
	}

	public StaticAgentBehaviour GetCurrentAgent () {
		return containedAgent;
	}

	public void Setup (MapController controller, WorldController world, MapLocation location, MapQuadrant quadrant) {
		this.Location = location;
		this.controller = controller;
		this.world = world;
		this.Quadrant = quadrant;
	}
		
	public void ShowValidBuild () {
		SetTileColor(validBuildColor);
	}

	public void PlaceStaticAgent (StaticAgentBehaviour agent, bool shouldPlaySound = true) {
		agent.SetTile(this);
		if (isIlluminated || agent is CoreOrbBehaviour) {
			this.containedAgent = agent;
			agent.transform.SetParent(transform);
			agent.transform.localPosition = Vector3.zero;
			agent.SetLocation(this.Location);
			if (agent is TowerBehaviour) {
				handlePlaceTower(agent as TowerBehaviour, shouldPlaySound);
			}
			agent.ToggleActive(true);
			agent.ToggleColliders(true);
			agent.transform.position += Vector3.up * TOWER_HEIGHT_OFFSET;
		} else {
			if (shouldPlaySound) {
				EventController.Event(EventType.TowerCannotPlace);
			}
			if (agent is TowerBehaviour) {
				controller.HandleTowerNotPlaced(agent as TowerBehaviour);
			} else {
				// TODO: Collect in object pool instead of destroying
				Destroy(agent.gameObject);
			}
		}
		Unhighlight();
	}
		
	void handlePlaceTower (TowerBehaviour tower, bool shouldPlaySound) {
		if (tower.HasIllumination) {
			handleIllumination(tower, shouldPlaySound);
		}
		MapController.Instance.AddActiveTower(tower);
		// Should be called last in order for illumination to refresh correctly
		if (shouldPlaySound) {
			tower.CallBuildEvent();
		}
	}

	void handleIllumination (ILightSource light, bool shoudPlaySound, bool onTowerPlace = true) {
		controller.Illuminate(this.Location, light, shoudPlaySound, onTowerPlace);
	}

	bool checkToUpdateIllumination (ILightSource light) {
		if (light == null && this.containedAgent is TowerBehaviour) light = this.containedAgent as TowerBehaviour;
		if (light is TowerBehaviour) {
			TowerBehaviour tower = light as TowerBehaviour;
			if (tower.ShouldReculateIllumination()) {
				tower.UpdateIlluminationRadius();
				handleIllumination(tower, shoudPlaySound:false);
			}
			return true;
		} else {
			return false;
		}
	}

	public void IlluminateSquare (ILightSource light, bool shouldPlaySound = true, bool onTowerPlace = false) {
		// Terminates if the light is already counted
		if (lightSources.Contains(light)) {
			return;
		} else {
			lightSources.Add(light);
		}

		if (!isIlluminated) {
			SetTileColor(illuminatedColor);
			if (shouldPlaySound) {
				EventController.Event(EventType.IlluminationOn);
			}
		}
		_illuminationSourceCount++;
		if (!(light == null || light as StaticAgentBehaviour == containedAgent || onTowerPlace)) {
			checkToUpdateIllumination(light);
		}
	}

	public void DelluminateSquare (bool shouldPlaySound = true) {
		if (isIlluminated) {
			_illuminationSourceCount = 0;
			lightSources.Clear();
			SetTileColor(standardColor);
			if (shouldPlaySound) {
				EventController.Event(EventType.IlluminationOff);
			}
		}
		checkToUpdateIllumination(null);
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
		if (HasAgent()) {
			SetTileColor(illuminatedColor);
		} else {
			setToPreviousColor();
		}
	}

	public void RemoveAgent () {
		containedAgent = null;
	}

	public float GetDistance (Vector3 fromWorldPosition) {
		return Vector3.Distance(transform.position, fromWorldPosition);
	}

	public override string ToString () {
		return string.Format ("[MapTileBehaviour: ({0}, {1})]", Location.X, Location.Y);
	}

	public bool CanPlaceTower () {
		return isIlluminated && !HasAgent();
	}

	public bool TryPlaceSelectedTower () {
		if (CanPlaceTower() && world.HasTowerToPlace) {		
			PlaceStaticAgent(world.GetPurchaseTowerToPlace(transform.position));
			return true;
		} else {
			if (!world.HasTowerToPlace) {
				EventController.Event(EventType.TowerCannotPlace);
			}
			return false;
		}
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
