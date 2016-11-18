/*
 * Author(s): Isaiah Mann
 * Description: Behaviour for an assault tower
 */

using UnityEngine;
using System.Collections;

public class AssaultTowerBehaviour : TowerBehaviour {
	const string LIGHTNING_TOWER_KEY = "Lightning Tower";
	const string FLAME_TOWER_KEY = "Flame Tower";

	protected override void SetReferences () {
		base.SetReferences ();
	}
		
	public override void SetTower (Tower tower) {
		base.SetTower (tower);
		if (tower.Type == LIGHTNING_TOWER_KEY || tower.Type == FLAME_TOWER_KEY) {
			AttackType = AttackType.Energy;
		}
	}

	public override void Attack (ActiveObjectBehaviour activeAgent, int damage) {
		base.Attack (activeAgent, damage);
		EventController.Event(EventType.ArchersTowerAttack);
	}
}
