/*
 * Author(s): Isaiah Mann
 * Description: Controls all the towers in the game
 */

using UnityEngine;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class TowerController : UnitController<ITower, Tower, TowerList>, ITowerController {
	public GameObject CoreOrbPrefab;
	public GameObject CoreOrbInstance;
	GameObject potentialPurchaseTower = null;
	MapTileBehaviour previousHighlightedMapTile = null;
	HashSet<TowerBehaviour> activeTowers = new HashSet<TowerBehaviour>();

	public override void Setup (WorldController worldController, IDataController dataController, string unitTemplateJSONPath) {
		base.Setup(worldController, dataController, unitTemplateJSONPath);
	}
		
	public void HandleBeginDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		if (potentialPurchaseTower != null) {
			Destroy(potentialPurchaseTower);
		}
		potentialPurchaseTower = (GameObject)Instantiate(worldController.GetTowerPrefab(towerPanel.TowerType));
		potentialPurchaseTower.GetComponent<TowerBehaviour>().ToggleColliders(false);
	}

	public void HandleDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		Vector3 dragPosition = dragEvent.position;
		dragPosition.z = towerPanel.transform.position.z - Camera.main.transform.position.z;
		dragPosition = Camera.main.ScreenToWorldPoint(dragPosition);
		dragPosition.y = dragPosition.z;
		potentialPurchaseTower.transform.position = dragPosition;
		HighlightSpotToPlace(dragPosition);
	}

	void HighlightSpotToPlace (Vector3 dragPosition) {
		MapTileBehaviour mapTile = MapController.Instance.GetTileFromPosition(dragPosition);
		if (mapTile) {
			if (previousHighlightedMapTile) {
				previousHighlightedMapTile.Unhighlight();
			}
			if (!mapTile.HasAgent()) {
				mapTile.HightlightToPlace(potentialPurchaseTower.GetComponent<StaticAgentBehaviour>());
				previousHighlightedMapTile = mapTile;
			}
		}
	}

	public void AddActiveTower (TowerBehaviour tower) {
		if (!activeTowers.Contains(tower)) {
			activeTowers.Add(tower);
		}
	}

	public void RemoveActiveTower (TowerBehaviour tower) {
		if (activeTowers.Contains(tower)) {
			activeTowers.Remove(tower);
		}
	}

	public void RefreshIlluminations () {
		foreach (TowerBehaviour tower in activeTowers) {
			if (tower is IlluminationTowerBehaviour) {
				worldController.SendIlluminationToMap(tower as IlluminationTowerBehaviour);
			}
		}
	}

	public void HandleEndDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		if (previousHighlightedMapTile && !previousHighlightedMapTile.HasAgent()) {
			previousHighlightedMapTile.PlaceAgent(potentialPurchaseTower.GetComponent<StaticAgentBehaviour>());
		} else {
			// TODO: Collect in object pool instead of destroying
			Destroy(potentialPurchaseTower);
		}
		potentialPurchaseTower = null;
	}

	public static TowerController Instance;

	public Tower[] GetActive() {
		throw new System.NotImplementedException ();
	}

	public void Create(Tower unit) {
		throw new System.NotImplementedException();
	}

	public void Destroy(Tower unit) {
		throw new System.NotImplementedException();
	}

	public Tower[] GetAll() {
		throw new System.NotImplementedException();
	}

	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}

	protected override void CleanupReferences () {
		base.CleanupReferences ();
		Instance = null;
	}
}
