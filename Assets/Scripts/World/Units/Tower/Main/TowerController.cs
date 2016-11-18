/*
 * Author(s): Isaiah Mann
 * Description: Controls all the towers in the game
 */

using UnityEngine;
using SimpleJSON;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Text.RegularExpressions;

public class TowerController : UnitController<ITower, Tower, TowerList>, ITowerController {
	public const string TOWER_TAG = "Tower";
	const float DRAG_HEIGHT_OFFSET = 3f;
	CameraController gameCamera;

	public GameObject CoreOrbPrefab;
	public GameObject CoreOrbInstance;
	TowerBehaviour potentialPurchaseTower = null;
	MapTileBehaviour previousHighlightedMapTile = null;
	HashSet<TowerBehaviour> activeTowers = new HashSet<TowerBehaviour>();
	Dictionary<TowerType, List<Tower>> towerTemplatesByType = new Dictionary<TowerType, List<Tower>>();
	public Dictionary<TowerType, List<Tower>> ITowerTemplatesByType {
		get {
			return towerTemplatesByType;
		}
	}
	public override void Setup (WorldController worldController, DataController dataController, MapController mapController, string unitTemplateJSONPath) {
		base.Setup(worldController, dataController, mapController, unitTemplateJSONPath);
		towerTemplatesByType = sortTowers(templateUnits.Values.ToArray());
	}

	public void SellTower (Tower tower) {
		worldController.OnSellTower(tower);
	}

	public void PlaceCoreOrb (MapTileBehaviour mapTile) {
		GameObject coreOrb = (GameObject) Instantiate(CoreOrbPrefab);
		CoreOrbInstance = coreOrb;
		CoreOrbBehaviour coreOrbBehaviour = coreOrb.GetComponent<CoreOrbBehaviour>();
		coreOrbBehaviour.SetTower(templateUnits[CoreOrbBehaviour.CORE_ORB_KEY]);
		mapTile.PlaceStaticAgent(coreOrbBehaviour, false);
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
		Vector3 startPosition = getDragPosition(dragEvent, towerPanel.transform.position);
		this.potentialPurchaseTower = GetTowerBehaviourFromTower(towerPanel.GetTower(), startPosition, false);

	}

	public TowerBehaviour GetTowerBehaviourFromTower (Tower tower, Vector3 startPosition, bool shouldStartActive = false) {
		TowerBehaviour potentialPurchaseTower = SpawnTower(tower, startPosition);
		potentialPurchaseTower.Setup(this);
		potentialPurchaseTower.ToggleColliders(shouldStartActive);
		potentialPurchaseTower.SetTower(tower);
		potentialPurchaseTower.ToggleActive(shouldStartActive);
		potentialPurchaseTower.OnSpawn();
		return potentialPurchaseTower;
	}

	public TowerBehaviour GetPrefab (Tower tower) {
		return loadPrefab(FileUtil.CreatePath(TOWER_TAG, PREFABS_DIR, tower.Type)) as TowerBehaviour;
	}
		
	TowerBehaviour SpawnTower (Tower tower, Vector3 startingPosition) {
		ActiveObjectBehaviour behaviour;
		if (TryGetActiveObject(tower.IType, startingPosition, out behaviour)) {
			return behaviour as TowerBehaviour;
		} else {
			TowerBehaviour prefabInResources = GetPrefab(tower);
			if (prefabInResources) {
				return Instantiate(prefabInResources);
			} else {
				return Instantiate(worldController.GetTowerPrefab(tower.TowerType)).GetComponent<TowerBehaviour>();
			}
		}
	}
		
	public void HandleDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		potentialPurchaseTower.transform.position = getDragPosition(dragEvent, towerPanel.transform.position);
		HighlightSpotToPlace(potentialPurchaseTower.transform.position);
	}

	Vector3 getDragPosition (PointerEventData pointerEvent, Vector3 panelPosition) {
		Vector3 dragPosition = pointerEvent.position;
		dragPosition.z = panelPosition.z - Camera.main.transform.position.z;
		dragPosition = Camera.main.ScreenToWorldPoint(dragPosition);
		// dragPosition.y = DRAG_HEIGHT_OFFSET;
		float angle = gameCamera.ICameraAngleRad;
		Vector3 offset = new Vector3(
			0,
			-Mathf.Cos(angle) * DRAG_HEIGHT_OFFSET,
			Mathf.Sin(angle) * DRAG_HEIGHT_OFFSET
		);
		return dragPosition + offset;
	}

	void HighlightSpotToPlace (Vector3 dragPosition) {
		RaycastHit hit;
		if (Physics.Raycast(dragPosition, gameCamera.ICameraDirection, out hit)) {
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


    public void compareTowerLevels() {


        foreach (Tower tower in templateUnits.Values) {

            if (tower.UnlockLevel == dataController.PlayerLevel) {


                TowerUnlockedScreen.towerUnlocked = true;
                TowerUnlockedScreen.textToDisplay = "Tower Unlocked.";


            }



        }

    }

    public override void HandleObjectDestroyed (ActiveObjectBehaviour activeObject) {
		base.HandleObjectDestroyed (activeObject);
		activeTowers.Remove(activeObject as TowerBehaviour);
	}

	public void HandleEndDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		if (previousHighlightedMapTile && previousHighlightedMapTile.CanPlaceTower()) {
			previousHighlightedMapTile.PlaceStaticAgent(potentialPurchaseTower);
			towerPanel.OnPurchased();
		} else {
			// TODO: Collect in object pool instead of destroying
			Destroy(potentialPurchaseTower.gameObject);
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

	public void HealAllTowers (){
		for (int i = 0; i < activeTowers.Count; i++) {
			int TowerMaxHealth = activeTowers.ElementAt (i).IMaxHealth;

			activeTowers.ElementAt (i).Heal (TowerMaxHealth);
		}
	}

    public void DestroyAllTowers() {
        foreach (TowerBehaviour tower in activeTowers) {         
            if (!(tower is CoreOrbBehaviour)) {
                tower.Destroy();
            }

        }
		activeTowers.Clear();
		activeTowers.Add(CoreOrbInstance.GetComponent<CoreOrbBehaviour>());
    }

    public void ToggleGodMode() {
        for (int i = 0; i < activeTowers.Count; i++) {
            activeTowers.ElementAt(i).isInvulnerable = !activeTowers.ElementAt(i).isInvulnerable;
        }
    }

	public Tower[] GetAll() {
		throw new System.NotImplementedException();
	}

	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		gameCamera = CameraController.Instance;
	}

	protected override void CleanupReferences () {
		base.CleanupReferences ();
		Instance = null;
	}

	public Sprite GetTowerSprite (string towerKey) {
		// Remove special characters from tower key (to produce filename)
		Regex rgx = new Regex("[^a-zA-Z0-9 -]");
		towerKey = rgx.Replace(towerKey, "");
		return Resources.Load<Sprite>(Path.Combine(TOWER_TAG, (Path.Combine(SPRITES_DIR, towerKey.ToLower().Replace(" ", string.Empty)))));
	}
}
