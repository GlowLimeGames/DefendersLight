/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of barricade towers. Immovable, defensive structures, typically no purpose beyond absorbing damage and blcoking the enemy
 */

using UnityEngine;
using System.Collections;

public class BarricadeTowerBehaviour : TowerBehaviour {
	protected override void SetReferences() {
		base.SetReferences();
		HasAttack = false;
    }
}
