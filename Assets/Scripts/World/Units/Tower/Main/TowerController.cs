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
	GameObject potentialPurchaseTower = null;
	float dragHeight;
	MapTileBehaviour previousHighlightedMapTile = null;

	public void Setup (WorldController worldController, IDataController dataController, string unitTemplateJSONPath, float dragHeight) {
		base.Setup(worldController, dataController, unitTemplateJSONPath);
		this.dragHeight = dragHeight;
	}
		
	public void HandleBeginDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		if (potentialPurchaseTower != null) {
			Destroy(potentialPurchaseTower);
		}
		potentialPurchaseTower = (GameObject)Instantiate(worldController.ITowerPrefab);
	}

	public void HandleDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		Vector3 dragPosition = dragEvent.position;
		dragPosition.z = towerPanel.transform.position.z - Camera.main.transform.position.z;
		dragPosition = Camera.main.ScreenToWorldPoint(dragPosition);
		dragPosition.y = dragHeight;
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
					mapTile.HightlightToPlace(potentialPurchaseTower.GetComponent<AssaultTowerBehaviour>());
					previousHighlightedMapTile = mapTile;
				}
			}
		}
	}

	public void HandleEndDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		if (previousHighlightedMapTile && !previousHighlightedMapTile.HasAgent()) {
			previousHighlightedMapTile.PlaceAgent(potentialPurchaseTower.GetComponent<AssaultTowerBehaviour>());
		} else {
			worldController.CheckInObject(potentialPurchaseTower, typeof(AssaultTower));
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
}
