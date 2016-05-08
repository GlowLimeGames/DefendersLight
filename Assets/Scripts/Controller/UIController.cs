using UnityEngine;
using System.Collections;

public class UIController : MannBehaviour {
	public static UIController Instance;

	[SerializeField]
	TowerPanelController TowerPanel;

	public void SelectTower (TowerBehaviour tower) {
		TowerPanel.SelectTower(tower);	
	}
		
	protected override void FetchReferences () {

	}

	protected override void SetReferences () {
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}

	}

	protected override void HandleNamedEvent (string eventName) {

	}

}
