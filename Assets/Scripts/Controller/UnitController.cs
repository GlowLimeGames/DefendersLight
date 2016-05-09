using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitController : MannBehaviour {
	public List<ActiveObjectBehaviour> Units = new List<ActiveObjectBehaviour>();

	protected override void FetchReferences() {

	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent(string eventName) {

	}
}
