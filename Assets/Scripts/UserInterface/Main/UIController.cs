/*
 * Author(s): Isaiah Mann
 * Description: Controls the behaviour and display of the user interface
 */

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

	protected override void CleanupReferences () {
		Instance = null;
	}

	protected override void HandleNamedEvent (string eventName) {

	}

}
