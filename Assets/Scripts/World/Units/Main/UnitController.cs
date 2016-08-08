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

	public List<ActiveObjectBehaviour> Units = new List<ActiveObjectBehaviour>();

	protected IWorldController controller;

	#region Constructors

	public UnitController (IWorldController controller, string unitTemplateJSON) {
		this.controller = controller;
		CreateUnitTemplates(unitTemplateJSON);
	}

	#endregion

	protected override void FetchReferences() {

	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent(string eventName) {

	}

	public abstract void CreateUnitTemplates(string jsonText);
}
