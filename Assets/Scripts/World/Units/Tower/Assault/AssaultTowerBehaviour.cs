/*
 * Author(s): Isaiah Mann
 * Description: Behaviour for an assault tower
 */

using UnityEngine;
using System.Collections;

public class AssaultTowerBehaviour : TowerBehaviour {
	const string ARCHERS_TOWER = "Archer's Tower";
	public override void Attack (ActiveObjectBehaviour activeAgent, int damage) {
		base.Attack (activeAgent, damage);
		if (activeAgent.IType.Equals(ARCHERS_TOWER)) {
			EventController.Event(EventType.ArchersTowerAttack);
		}
	}
}
