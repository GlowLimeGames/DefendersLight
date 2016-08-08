/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public class IlluminationTower : Tower {
	public IlluminationTower (string type, int health, IMapLocation location, string description, int cost, int unlockLevel,
		IWorldController worldController, ITowerController towerController, int illuminationRadius = 0) : 
	base(type, health, location, description, cost, unlockLevel, worldController, towerController,
		ATTACK_STAT_DEFAULT, ATTACK_STAT_DEFAULT, ATTACK_STAT_DEFAULT, ATTACK_STAT_DEFAULT, illuminationRadius) {}
}
