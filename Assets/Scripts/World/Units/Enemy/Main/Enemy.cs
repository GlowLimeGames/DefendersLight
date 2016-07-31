/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public class Enemy : Unit {
	RewardAmount _deathReward;
	public RewardAmount DeathReward {
		get {
			return this._deathReward;
		}
	}

	public Enemy (string type, int health, int damage, float cooldown, int range, int attackRadius, IMapLocation location, string description, RewardAmount deathReward) : 
	base(type, health, damage, cooldown, range, attackRadius, location, description) {
		this._deathReward = deathReward;
	}
}
