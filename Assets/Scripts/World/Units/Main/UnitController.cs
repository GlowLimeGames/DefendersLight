/*
 * Author(s): Isaiah Mann
 * Description: Template controller for controlling units
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitController : MannBehaviour {
	protected IList<IUnit> _activeUnits;
	public IUnit[] ActiveUnits{
		get {
			IUnit[] activeUnits = new IUnit[_activeUnits.Count];
			this._activeUnits.CopyTo(activeUnits, 0);
			return activeUnits;
		}
	}

	public List<ActiveObjectBehaviour> Units = new List<ActiveObjectBehaviour>();

	protected IWorldController controller;

	#region Constructors
	public UnitController (IWorldController controller) {
		this.controller = controller;
	}
	#endregion

	protected override void FetchReferences() {

	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent(string eventName) {

	}
}
