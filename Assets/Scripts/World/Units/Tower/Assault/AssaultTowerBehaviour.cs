/*
 * Author(s): Isaiah Mann
 * Description: Behaviour for an assault tower
 */

using UnityEngine;
using System.Collections;

public class AssaultTowerBehaviour : TowerBehaviour {
	public override void Attack (ActiveObjectBehaviour activeAgent) {
		base.Attack (activeAgent);
		EventController.Event(EventType.ArchersTowerAttack);
	}
}
