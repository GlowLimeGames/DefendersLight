/*
 * Author(s): Isaiah Mann
 * Description: Template controller for controlling units
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitController<UnitType> : MannBehaviour where UnitType:IUnit {
	protected Dictionary<string, UnitType> templateUnits;
	protected IList<UnitType> _activeUnits;
	public UnitType[] ActiveUnits{
		get {
			UnitType[] activeUnits = new UnitType[_activeUnits.Count];
			this._activeUnits.CopyTo(activeUnits, 0);
			return activeUnits;
		}
	}
		
	List<ActiveObjectBehaviour> _units = new List<ActiveObjectBehaviour>();
	public List<ActiveObjectBehaviour> Units {
		get {
			return _units;
		}
	}

	protected IWorldController worldController;
	protected IDataController dataController;

	public virtual void Setup (IWorldController worldController, IDataController dataController, string unitTemplateJSONPath) {
		this.worldController = worldController;
		this.dataController = dataController;
		string unitTemplateJSON = dataController.RetrieveJSONFromResources(unitTemplateJSONPath);
		CreateUnitTemplates(unitTemplateJSON);
	}

	public virtual void CreateUnitTemplates(string jsonText) {
		UnitType[] tempUnitTemplates = JsonUtility.FromJson<UnitType[]>(jsonText);
		templateUnits = new Dictionary<string, UnitType>();
		foreach (UnitType unit in tempUnitTemplates) {
			templateUnits.Add(unit.Type, unit);
		}
		Debug.Log(tempUnitTemplates.Length);
	}

	protected override void FetchReferences() {

	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent(string eventName) {

	}
		
}
