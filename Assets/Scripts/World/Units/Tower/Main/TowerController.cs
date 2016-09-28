﻿/*
 * Author(s): Isaiah Mann
 * Description: Controls all the towers in the game
 */

using UnityEngine;
using SimpleJSON;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class TowerController : UnitController<ITower, Tower, TowerList>, ITowerController {
	public const string TOWER_TAG = "Tower";
	const float DRAG_HEIGHT_OFFSET = 1.25f;

	public GameObject CoreOrbPrefab;
	public GameObject CoreOrbInstance;
	GameObject potentialPurchaseTower = null;
	MapTileBehaviour previousHighlightedMapTile = null;
	HashSet<TowerBehaviour> activeTowers = new HashSet<TowerBehaviour>();
	Dictionary<TowerType, List<Tower>> towerTemplatesByType = new Dictionary<TowerType, List<Tower>>();

	public override void Setup (WorldController worldController, DataController dataController, string unitTemplateJSONPath) {
		base.Setup(worldController, dataController, unitTemplateJSONPath);
		towerTemplatesByType = sortTowers(templateUnits.Values.ToArray());
	}

	public void PlaceCoreOrb (MapTileBehaviour mapTile) {
		GameObject coreOrb = (GameObject) Instantiate(CoreOrbPrefab);
		CoreOrbInstance = coreOrb;
		CoreOrbBehaviour coreOrbBehaviour = coreOrb.GetComponent<CoreOrbBehaviour>();
		mapTile.PlaceAgent(coreOrbBehaviour, false);
		coreOrbBehaviour.SetTower(templateUnits[CoreOrbBehaviour.CORE_ORB_KEY]);
	}

	Dictionary<TowerType, List<Tower>> sortTowers (Tower[] towers) {
		Dictionary<TowerType, List<Tower>> sortedTowers = new Dictionary<TowerType, List<Tower>>();
		for (int i = 0; i < System.Enum.GetNames(typeof(TowerType)).Length; i++) {
			sortedTowers.Add((TowerType)i, new List<Tower>());
		}
		foreach (Tower tower in towers) {
			if (includeTowerInTypes(tower)) {
				sortedTowers[tower.TowerType].Add(tower);
			}
		}
		return sortedTowers;
	}

	bool includeTowerInTypes (Tower tower) {
		return tower.Type != CoreOrbBehaviour.CORE_ORB_KEY;
	}

	public Tower[] GetTowersOfType (TowerType type) {
		List<Tower> towers;
		if (towerTemplatesByType.TryGetValue(type, out towers)) {
			return towers.ToArray();
		} else {
			return new Tower[0];
		}
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
		dragPosition.y = DRAG_HEIGHT_OFFSET;
		potentialPurchaseTower.transform.position = dragPosition;
		HighlightSpotToPlace(dragPosition);
	}

	void HighlightSpotToPlace (Vector3 dragPosition) {
		RaycastHit hit;
		if (Physics.Raycast(dragPosition, Vector3.down, out hit)) {
			MapTileBehaviour mapTile;
			if (hit.collider != null && (mapTile = hit.collider.GetComponent<MapTileBehaviour>()) != null) {
				if (previousHighlightedMapTile) {
					previousHighlightedMapTile.Unhighlight();
				}
				if (!mapTile.HasAgent()) {
					mapTile.HightlightToPlace(potentialPurchaseTower.GetComponent<StaticAgentBehaviour>());
					previousHighlightedMapTile = mapTile;
				}
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
			towerPanel.OnPurchased();
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
