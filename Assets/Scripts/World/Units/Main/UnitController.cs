/*
 * Author(s): Isaiah Mann
 * Description: Template controller for controlling units
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitController : MannBehaviour {
	public abstract Unit[] GetUnits();
}

public abstract class UnitController<IUnitType, UnitType, UnitList> : UnitController 
	where IUnitType:IUnit 
	where UnitType:Unit 
	where UnitList:UnitCollection<UnitType> {

	protected Dictionary<string, UnitType> templateUnits;
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
		
	protected IWorldController worldController;
	protected IDataController dataController;

	public virtual void Setup (IWorldController worldController, IDataController dataController, string unitTemplateJSONPath) {
		this.worldController = worldController;
		this.dataController = dataController;
		string unitTemplateJSON = dataController.RetrieveJSONFromResources(unitTemplateJSONPath);
		CreateUnitTemplates(unitTemplateJSON);
	}

	public virtual void CreateUnitTemplates(string jsonText) {
		UnitList tempUnitTemplates = JsonUtility.FromJson<UnitList>(jsonText);
		templateUnits = new Dictionary<string, UnitType>();
		foreach (UnitType unit in tempUnitTemplates.Units) {
			if (!string.IsNullOrEmpty(unit.IType)) {
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
