/*
 * Author(s): Isaiah Mann
 * Description: Controls the set up and behaviour of the game world
 */
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class WorldController : MannBehaviour, IWorldController, IObjectPool<GameObject> {
	public static WorldController Instance;
	bool isPaused;
	public GameObject TowerPrefab;
	public GameObject AssaulTowerPrefab;
	public GameObject BarricadeTowerPrefab;
	public GameObject IlluminationTowerPrefab;
	public GameObject EnemyPrefab;
	public GameObject ITowerPrefab {
		get {
			return TowerPrefab;
		}
	}
	public GameObject ICoreOrbInstance {
		get {
			return towerController.CoreOrbInstance;
		}
	}

	// TODO: Make this a tuning variable in a centralized tuning script
	public int MiniOrbsFromKillingEnemy = 25;

	const string TOWER_UNIT_TEMPLATE_FILE_NAME = "TowerTemplates";
	const string ENEMY_UNIT_TEMPLATE_FILE_NAME = "EnemyTemplates";

	Dictionary<System.Type, Stack<GameObject>> unitSpawnpool = new Dictionary<System.Type, Stack<GameObject>>();
	TowerController towerController;
	EnemyController enemyController;
	MapController mapController;
	UnitController[] unitControllers;
	DataController dataController;

	public void Create() {
		SetupUnitControllers();
		PlaceCoreOrb();
	}

	public void StartWave () {
		enemyController.SpawnWave();
	}

	public void CollectMiniOrbs (int count) {
		dataController.CollectMiniOrbs(count);
		StatsPanelController.Instance.SetMiniOrbs(dataController.MiniOrbCount);
	}

	public bool TrySpendMiniOrbs (int count) {
		if (dataController.TrySpendMiniOrbs(count)) {
			StatsPanelController.Instance.SetMiniOrbs(dataController.MiniOrbCount); 
			return true;
		} else {
			return false;
		}
	}

	public void TogglePause () {
		if (isPaused) {
			Resume();
		} else {
			Pause();
		}
	}

	public void Pause () {
		Time.timeScale = 0;
		isPaused = true;
	}

	public void Resume () {
		Time.timeScale = 1;
		isPaused = false;
	}

	void PlaceCoreOrb () {
		towerController.PlaceCoreOrb(mapController.GetCenterTile());
	}

	void SetupUnitControllers () {
		towerController.Setup(this, dataController, TOWER_UNIT_TEMPLATE_FILE_NAME);
		enemyController.Setup(this, dataController, ENEMY_UNIT_TEMPLATE_FILE_NAME);
		unitControllers = new UnitController[]{towerController, enemyController};
	}

	public void RefreshIlluminations () {
		towerController.RefreshIlluminations();
	}

	public void SendIlluminationToMap (IlluminationTowerBehaviour illuminationTower, bool shouldPlaySound = true) {
		MapController.Instance.Illuminate(illuminationTower.GetLocation(), illuminationTower.IlluminationRadius, shouldPlaySound);
	}

	// Cleans up/destroys the world
	public void Teardown() {
		throw new System.NotImplementedException();
	}
		
	public void AddActiveTower (TowerBehaviour tower) {
		towerController.AddActiveTower(tower);
	}

	public void RemoveActiveTower (TowerBehaviour tower) {
		towerController.RemoveActiveTower(tower);
	}

    public void RemoveActiveEnemy (EnemyBehaviour enemy) {
        enemyController.RemoveActiveEnemy(enemy);
    }

    public void HealAllTowers (){
		towerController.HealAllTowers ();
	}

    public void KillAllEnemies() {
        enemyController.KillAllEnemies();
    }

    public void ToggleGodMode() {
        towerController.ToggleGodMode();
    }
		
	public void AddObject(IWorldObject element) {
		throw new System.NotImplementedException();
	}

	public void RemoveObject(IWorldObject element) {
		throw new System.NotImplementedException();
	}

	public IWorldObject GetObject(string id) {
		throw new System.NotImplementedException();
	}
		
	public void HandleBeginDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		if (dragEvent != null) {
			towerController.HandleBeginDragPurchase(dragEvent, towerPanel);
		}
	}

	public void HandleDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		if (dragEvent != null) {
			towerController.HandleDragPurchase(dragEvent, towerPanel);
		}
	}

	public void HandleEndDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel) {
		if (dragEvent != null) {
			towerController.HandleEndDragPurchase(dragEvent, towerPanel);
		}
	}

	protected override void SetReferences () {
		SingletonUtil.TryInit(ref Instance, this, gameObject);
	}

	protected override void FetchReferences () {
		dataController = DataController.Instance;
		towerController = TowerController.Instance;
		enemyController = EnemyController.Instance;
		mapController = MapController.Instance;
		Create();
		StartWave();
		EventController.Event(EventType.LoadGame);
	}

	protected override void CleanupReferences () {
		Instance = null;
	}

	protected override void HandleNamedEvent (string eventName) {
		if (eventName == EventType.EnemyDestroyed) {
			CollectMiniOrbs(MiniOrbsFromKillingEnemy);
		}
	}
		
	void handleUnitEvent (string eventName, Unit unit) {
		if (eventName == EventType.EnemyDestroyed) {
			if (unit.Type == "Undead") {
				CollectMiniOrbs(25);
			} else if (unit.Type == "Brute") {
				CollectMiniOrbs(100);
			} else if (unit.Type == "Shade") {
				CollectMiniOrbs(200);
			}
		}
	}

	public string GenerateID (IUnit unit) {
		return unit.IType + System.Guid.NewGuid();
	}
		
	#region JSON Serialization

	public string SerializeAsJSON() {
		string worldAsJSON = string.Empty;
		foreach (UnitController controller in unitControllers) {
			foreach(Unit unit in controller.GetUnits()) {
				worldAsJSON += unit.SerializeAsJSON();
			}
		}
		print(worldAsJSON);
		return worldAsJSON;
	}

	public void SaveAsJSONToPath(string path) {
		throw new System.NotImplementedException();
	}

	public void DeserializeFromJSON(string jsonText) {
		throw new System.NotImplementedException();
	}

	public void DeserializeFromJSONAtPath(string jsonPath) {
		throw new System.NotImplementedException();
	}

	#endregion

	#region Input Handling

	public void HandleZoom (float zoomFactor) {
		throw new System.NotImplementedException();
	}

	public void HandlePan (Vector2 panDirection) {
		throw new System.NotImplementedException();
	}

	#endregion

	#region IObjectPool

	public GameObject CheckoutObject (params object[] arguments) {
		System.Type objectType = (System.Type) arguments[0];
		Stack<GameObject> objectsOfType;
		if (unitSpawnpool.TryGetValue(objectType, out objectsOfType) && objectsOfType.Count > 0) {
			return objectsOfType.Pop();
		} else {
			return NewObject(arguments);
		}
	}

	public GameObject NewObject (params object[] arguments) {
		System.Type objectType = (System.Type) arguments[0];
		return (GameObject) Instantiate(PrefabByType(objectType));
	}

	GameObject PrefabByType (System.Type type) {
		if (type.IsSubclassOf(typeof(Tower))) {
			return TowerPrefab;
		} else if (type.IsSubclassOf(typeof(Enemy))) {
			return EnemyPrefab;
		} else {
			return null;
		}
	}

	public GameObject[] CheckoutObjects (int count, object[] arguments) {
		GameObject[] objects = new GameObject[count];
		for (int i = 0; i < count; i++) {
			objects[i] = CheckoutObject(arguments);
		}
		return objects;
	}

	public void CheckInObject (GameObject instance, params object[] arguments) {
		System.Type objectType = (System.Type) arguments[0];
		if (!unitSpawnpool.ContainsKey(objectType)) {
			unitSpawnpool.Add(objectType, new Stack<GameObject>());
		}
		unitSpawnpool[objectType].Push(instance);
	}

	public void CheckInObjects (GameObject[] instances, params object[] arguments) {
		foreach (GameObject instance in instances) {
			CheckInObject(instance, arguments);
		}
	}

	#endregion

	public GameObject GetTowerPrefab (TowerType towerType) {
		switch (towerType) {
		case TowerType.Assault:
			return AssaulTowerPrefab;
		case TowerType.Barricade:
			return BarricadeTowerPrefab;
		case TowerType.Illumination:
			return IlluminationTowerPrefab;
		default:
			return null;
		}
	}

	public static void AttachBehaviourScript (System.Type unitType, GameObject instance) {
		if (unitType == typeof(AssaultTower)) {
			instance.AddComponent<AssaultTowerBehaviour>();
		} else if (unitType == typeof(BarricadeTower)) {
			instance.AddComponent<BarricadeTowerBehaviour>();
		} else if (unitType == typeof(IlluminationTower)) {
			instance.AddComponent<IlluminationTowerBehaviour>();
		} else if (unitType == typeof(Enemy)) {
			instance.AddComponent<EnemyBehaviour>();
		}
	}

	public static void AttackBehaviourScript (TowerType towerType, GameObject instance) {
		switch (towerType) {
		case TowerType.Assault:
			instance.AddComponent<AssaultTowerBehaviour>();
			break;
		case TowerType.Barricade:
			instance.AddComponent<BarricadeTowerBehaviour>();
			break;
		case TowerType.Illumination:
			instance.AddComponent<IlluminationTowerBehaviour>();
			break;
		}
	}

	protected override void SubscribeEvents () {
		base.SubscribeEvents ();
		EventController.OnUnitEvent += handleUnitEvent;
	}

	protected override void UnusbscribeEvents () {
		base.UnusbscribeEvents ();
		EventController.OnUnitEvent -= handleUnitEvent;
	}

	#region TowerController

	public Tower[] GetTowersOfType (TowerType type) {
		return towerController.GetTowersOfType(type);
	}

	public Sprite GetTowerSprite (string towerKey) {
		return towerController.GetTowerSprite(towerKey);
	}

	#endregion
}
