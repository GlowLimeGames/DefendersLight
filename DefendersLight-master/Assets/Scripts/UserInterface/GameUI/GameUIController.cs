/*
 * Author(s): Isaiah Mann
 * Description: Controls the behaviour and display of the user interface
 */

using UnityEngine;
using System.Collections;

public class GameUIController : UIController {
	public static GameUIController Instance;

	[SerializeField]
	TowerPanelController TowerPanel;

	public void SelectTower (TowerBehaviour tower) {
		TowerPanel.SelectTower(tower);	
	}

	protected override void SetReferences () {
		base.SetReferences();
		if (!SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			Destroy(gameObject);
		}
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
		SingletonUtil.TryCleanupSingleton(ref Instance, this);
	}
}
