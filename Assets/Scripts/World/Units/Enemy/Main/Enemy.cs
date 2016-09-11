/*
 * Author(s): Isaiah Mann
 * Description: Represents a basic enemy
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

	public Enemy (string type, int health, int damage, float cooldown, int range, int attackRadius, MapLocation location, string description, RewardAmount deathReward,
		IWorldController worldController, IEnemyController enemyController) : 
	base(type, health, damage, cooldown, range, attackRadius, location, description, worldController) {
		this.DeathReward = deathReward;
		this.enemyController = enemyController;
	}

	public Enemy (string jsonText):base(jsonText){}

	public override void Copy (Unit unit) {
		base.Copy(unit);
		try {
			Enemy enemyData = (Enemy) unit;
			this.DeathReward = enemyData.DeathReward;
		} catch {
			UnityEngine.Debug.LogWarningFormat("Unable to fully copy unit. Is not of type {0}", this.GetType());
		}
	}

	public override void DeserializeFromJSON(string jsonText) {
		Enemy enemyData = UnityEngine.JsonUtility.FromJson<Enemy>(jsonText);
		Copy(enemyData);
	}

	public override void DeserializeFromJSONAtPath(string jsonPath) {

	}
}
