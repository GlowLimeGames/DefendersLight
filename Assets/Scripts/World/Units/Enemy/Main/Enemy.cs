/*
 * Author(s): Isaiah Mann
 * Description: 
 */

[System.Serializable]
public class Enemy : Unit {
	#region JSON Keys

	public const string REWARDS_KEY = "Death Rewards";

	#endregion

	IEnemyController enemyController;
	public RewardAmount DeathReward;
	public RewardAmount IDeathReward {
		get {
			return this.DeathReward;
		}
	}

	public Enemy (string type, int health, int damage, float cooldown, int range, int attackRadius, IMapLocation location, string description, RewardAmount deathReward,
		IWorldController worldController, IEnemyController enemyController) : 
	base(type, health, damage, cooldown, range, attackRadius, location, description, worldController) {
		this.DeathReward = deathReward;
		this.enemyController = enemyController;
	}

}
