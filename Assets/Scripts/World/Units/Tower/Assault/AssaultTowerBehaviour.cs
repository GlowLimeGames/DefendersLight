/*
 * Author(s): Isaiah Mann
 * Description: Behaviour for an assault tower
 */

using UnityEngine;
using System.Collections;

public class AssaultTowerBehaviour : TowerBehaviour {
	public override void Attack (ActiveObjectBehaviour activeAgent, int damage) {
		base.Attack (activeAgent, damage);
		EventController.Event(EventType.ArchersTowerAttack);
	}
}
