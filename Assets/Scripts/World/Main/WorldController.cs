/*
 * Author(s): Isaiah Mann
 * Description: Controls the set up and behaviour of the game world
 */
using UnityEngine;
using System.Collections.Generic;

public class WorldController : MannBehaviour, IWorldController {
	const string TOWER_UNIT_TEMPLATE_FILE_NAME = "TowerTemplates.json";
	const string ENEMY_UNIT_TEMPLATE_FILE_NAME = "EnemyTemplates.json";

	List<GameObject> unitSpawnpool = new List<GameObject>();
	ITowerController towerController;
	IEnemyController enemyController;
	IDataController dataController;

	public void Create() {
		// string towerTemplatesJSON = dataController.r
		/* 
		 * TODO:
		 * 1. Get Tower Templates
		 * 2. Call towercontroller constructor
		 * 3. Get Enemy Templates
		 * 4. Call enemycontroller constructor
		 */

	}

	// Cleans up/destroys the world
	public void Teardown() {
		throw new System.NotImplementedException();
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
		
	protected override void SetReferences () {
		
	}

	protected override void FetchReferences () {
		towerController = TowerController.Instance;
		enemyController = EnemyController.Instance;
		// TODO: Fetch reference to datacontroller
	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent (string eventName) {

	}
		
	public string GenerateID (IUnit unit) {
		return unit.Type + System.Guid.NewGuid();
	}
		
	#region JSON Serialization

	public string SerializeAsJSON() {
		throw new System.NotImplementedException();
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
}