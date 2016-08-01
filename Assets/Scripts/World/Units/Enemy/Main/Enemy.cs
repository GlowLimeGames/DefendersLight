/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public class Enemy : Unit {
	IEnemyController controller;
	RewardAmount _deathReward;
	public RewardAmount DeathReward {
		get {
			return this._deathReward;
		}
	}

	public Enemy (string type, int health, int damage, float cooldown, int range, int attackRadius, IMapLocation location, string description, RewardAmount deathReward,
		IWorldController worldController, IEnemyController enemyController) : 
	base(type, health, damage, cooldown, range, attackRadius, location, description, worldController) {
		this._deathReward = deathReward;
		this.controller = enemyController;
	}
}
