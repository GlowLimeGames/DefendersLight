/*
 * Author(s): Isaiah Mann
 * Description: Controls all the towers in the game
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerController : UnitController<ITower>, ITowerController {
	public static TowerController Instance;

	#region Constructors

	public TowerController (IWorldController controller, string unitTemplateJSON):base(controller, unitTemplateJSON) {

	}

	#endregion

	public ITower[] GetActive() {
		throw new System.NotImplementedException ();
	}

	public void Create(ITower unit) {
		throw new System.NotImplementedException();
	}

	public void Destroy(ITower unit) {
		throw new System.NotImplementedException();
	}

	public ITower[] GetAll() {
		throw new System.NotImplementedException();
	}

	public override void CreateUnitTemplates (string jsonText) {
		throw new System.NotImplementedException ();
	}

	protected override void SetReferences() {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}
}
