/*
 * Author(s): Isaiah Mann
 * Description: Template controller for controlling units
 */

using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitController : MannBehaviour {
	[SerializeField]
	protected bool inGame = true;
	protected const string PROJECTILE_DIR = "Projectile";
	protected const string SPRITES_DIR = "Sprites";
	protected const string PREFABS_DIR = "Prefabs";

	public abstract Unit[] GetUnits();

	protected WorldController worldController;
	protected DataController dataController;
	protected MapController mapController;

	protected bool TryGetActiveObject (string objectType, Vector3 objectStartingPosition, out ActiveObjectBehaviour activeObject) {
		bool successful = worldController.TryPullFromSpawnPool(objectType, out activeObject);
		if (successful) {
			activeObject.transform.position = objectStartingPosition;
			activeObject.gameObject.SetActive(true);
		}
		return successful;
	}

	public virtual void HandleObjectDestroyed (ActiveObjectBehaviour activeObject) {
		activeObject.gameObject.SetActive(false);
		worldController.AddToSpawnPool(activeObject);
	}

	public virtual void Setup (WorldController worldController, DataController dataController, MapController mapController) {
		this.worldController = worldController;
		this.dataController = dataController;
		this.mapController = mapController;
	}
		
	protected ActiveObjectBehaviour loadPrefab (string pathInResources) {
		return Resources.Load<ActiveObjectBehaviour>(pathInResources);
	} 

	// Public so individuals units can access it
	public ProjectileBehaviour loadProjectilePrefab (string projectileNamne) {
		return loadPrefab(FileUtil.CreatePath(PROJECTILE_DIR, PREFABS_DIR, projectileNamne)) as ProjectileBehaviour;
	}
	
}

public abstract class UnitController<IUnitType, UnitType, UnitList> : UnitController 
	where IUnitType:IUnit 
	where UnitType:Unit 
	where UnitList:UnitCollection<UnitType> {

	protected Dictionary<string, UnitType> templateUnits;
	public Unit[] ITemplateUnits {
		get {
			return templateUnits.Values.ToArray();
		}
	}
	protected IList<UnitType> _activeUnits;
	public UnitType[] ActiveUnits{
		get {
			UnitType[] activeUnits = new UnitType[_activeUnits.Count];
			this._activeUnits.CopyTo(activeUnits, 0);
			return activeUnits;
		}
	}
		
	List<UnitType> _units = new List<UnitType>();
	public List<UnitType> Units {
		get {
			return _units;
		}
	}

	public virtual void Setup (WorldController worldController, DataController dataController, MapController mapController, string unitTemplateJSONPath) {
		Setup(worldController, dataController, mapController);
		string unitTemplateJSON = dataController.RetrieveJSONFromResources(unitTemplateJSONPath);
		CreateUnitTemplates(unitTemplateJSON);
	}

	public virtual void CreateUnitTemplates(string jsonText) {
		UnitList tempUnitTemplates = JsonUtility.FromJson<UnitList>(jsonText);
		templateUnits = new Dictionary<string, UnitType>();
		foreach (UnitType unit in tempUnitTemplates.Units) {
			if (!string.IsNullOrEmpty(unit.IType)) {
				// Template units should be at full health:
				unit.ResetHealth();
				templateUnits.Add(unit.IType, unit);
			}
		}
	}

	public virtual void SpawnUnits (string jsonText) {
		UnitList unitsOnField = JsonUtility.FromJson<UnitList>(jsonText);
		foreach (UnitType unit in unitsOnField.Units) {

		}
	}

	public override Unit[] GetUnits () {
		return Units.ToArray();
	}

	protected override void FetchReferences() {
		
	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent(string eventName) {

	}
		
}
