/*
 * Author(s): Isaiah Mann
 * Description: Data about the game world
 */

[System.Serializable]
public class WorldState : IWorldState, ISessionData {
	int startingMana;
	public int Mana;
	public int EnemiesKilled;
	public int CurrentWave;
	public int XPEarned;
	string filePath;
	public string IFilePath {
		get {
			return filePath;
		} 
		set {
			filePath = value;
		}
	}

	#region Properties

	public int IMana {
		get {
			return this.Mana;
		}
	}
	public int IXP {
		get {
			return this.XPEarned;
		}
	}
	#endregion

	public WorldState (string filePath, int startingMana) {
		this.filePath = filePath;
		this.startingMana = startingMana;
		Reset();
	}

	public void Reset () {
		Mana = this.startingMana;
		EnemiesKilled = 0;
		CurrentWave = 1;
		XPEarned = 0;
	}

	public void CollectMana (int mana) {
		this.Mana += mana;
	}

	public bool TrySpendMana (int mana) {
		bool returnValue = HasSufficientMana(mana);
		if (returnValue) {
			this.Mana -= mana;
		}
		return returnValue;
	}

	public bool HasSufficientMana (int mana) {
		return this.Mana >= mana;
	}

	public void NextWave () {
		CurrentWave++;
	}

	public void UpdateEnemiesKilled (int deltaEnemiesKilled) {
		this.EnemiesKilled += deltaEnemiesKilled;
	}

	public void UpdateXPEarned (int deltaXP) {
		this.XPEarned += deltaXP;
	}
}
