﻿/*
 * Author(s): Isaiah Mann
 * Description: 
 */

[System.Serializable]
public class BarricadeTower : Tower {

	public BarricadeTower (string type, int health, IMapLocation location, string description, int cost, int unlockLevel,
		IWorldController worldController, ITowerController towerController, string illuminationRadius = "0") : 
	base(type, health, location, description, cost, unlockLevel, worldController, towerController,
		ATTACK_STAT_DEFAULT, ATTACK_STAT_DEFAULT, ATTACK_STAT_DEFAULT, ATTACK_STAT_DEFAULT, illuminationRadius) {}
}
