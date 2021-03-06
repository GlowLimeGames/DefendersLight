﻿/*
 * Author(s): Isaiah Mann
 * Description: Represents an attack module (can be added to a tower or enemy)
 */

public class AttackBehaviour : MannBehaviour {
	protected Unit unit;
	protected ActiveObjectBehaviour parentObject;
	protected bool isActive;
	protected override void SetReferences () {
		parentObject = GetComponentInParent<ActiveObjectBehaviour>();
		if (parentObject) {
			isActive = true;
		} else {
			UnityEngine.Debug.LogError("{0} AttackBehaviour cannot locate a parent object");
		}
	}

	public virtual void SetUnit (Unit unit) {
		this.unit = unit;
	}

	protected override void FetchReferences () {

	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent (string eventName) {

	}
}