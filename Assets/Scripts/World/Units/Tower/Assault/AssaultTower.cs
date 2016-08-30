/*
 * Author(s): Isaiah Mann
 * Description: 
 */

[System.Serializable]
public class AssaultTower : Tower {
	public AssaultTower (string type, int health, IMapLocation location, string description, int cost, int unlockLevel,
		IWorldController worldController, ITowerController towerController,
		int damage = 0, float cooldown = 0, int range = 0, int attackRadius = 0, string illuminationRadius = "0") : 
	base(type, health, location, description, cost, unlockLevel, worldController, towerController,
		damage, cooldown, range, attackRadius, illuminationRadius) {}
}
