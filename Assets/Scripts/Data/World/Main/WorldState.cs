/*
 * Author(s): Isaiah Mann
 * Description: Data about the game world
 */

[System.Serializable]
public class WorldState : IWorldState, ISessionData {

	const int DEFAULT_ENEMIES_KILLED = 0;
	const int DEFAULT_CURRENT_WAVE = 1;
	const int DEFAULT_XP_EARNED = 0;

	int startingMana;
	public int Mana;
	public int EnemiesKilled;
	public int CurrentWave;
	public int XPEarned;
	public bool HighestWaveReachedInSession;
	public Enemy[] ActiveEnemies;
	public Tower[] ActiveTowers;
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

	public WorldState (string filePath, 
		int mana, 
		int enemiesKilled, 
		int wave, 
		int xpEarned, 
		Enemy[] activeEnemies, 
		Tower[] activeTowers) {
		this.Mana = mana;
		this.EnemiesKilled = enemiesKilled;
		this.CurrentWave = wave;
		this.XPEarned = xpEarned;
		this.ActiveEnemies = activeEnemies;
		this.ActiveTowers = activeTowers;
	}

	public void Reset () {
		Mana = this.startingMana;
		EnemiesKilled = DEFAULT_ENEMIES_KILLED;
		CurrentWave = DEFAULT_CURRENT_WAVE;
		XPEarned = DEFAULT_XP_EARNED;
		HighestWaveReachedInSession = false;
		this.ActiveEnemies = new Enemy[0];
		this.ActiveTowers = new Tower[0];
	}

	public bool HasDataToSave () {
		return !(Mana == this.startingMana &&
			this.EnemiesKilled == DEFAULT_ENEMIES_KILLED &&
			this.CurrentWave == DEFAULT_CURRENT_WAVE &&
			this.XPEarned == DEFAULT_XP_EARNED);
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
