/*
 * Author(s): Isaiah Mann
 * Description: 
 */

[System.Serializable]
public class BarricadeTower : Tower {

	public BarricadeTower (string type, int health, MapLocation location, string description, int cost, int unlockLevel,
		IWorldController worldController, ITowerController towerController, string illuminationRadius = "0") : 
	base(type, health, location, description, cost, unlockLevel, worldController, towerController,
		ATTACK_STAT_DEFAULT, ATTACK_STAT_DEFAULT, ATTACK_STAT_DEFAULT, illuminationRadius) {}

	public BarricadeTower (string jsonText):base(jsonText){}

	public override void DeserializeFromJSON(string jsonText) {
		BarricadeTower towerData = UnityEngine.JsonUtility.FromJson<BarricadeTower>(jsonText);
		Copy(towerData);
	}

	public override void DeserializeFromJSONAtPath(string jsonPath) {

	}
}
