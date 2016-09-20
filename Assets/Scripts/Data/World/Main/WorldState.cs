/*
 * Author(s): Isaiah Mann
 * Description: Data about the game world
 */

[System.Serializable]
public class WorldState : IWorldState, ISessionData {
	public int MiniOrbCount;
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

	public int IMiniOrbs {
		get {
			return this.MiniOrbCount;
		}
	}
	public int IXP {
		get {
			return this.XPEarned;
		}
	}
	#endregion

	public WorldState (string filePath) {
		this.filePath = filePath;
		Reset();
	}

	public void Reset () {
		MiniOrbCount = 0;
		EnemiesKilled = 0;
		CurrentWave = 1;
		XPEarned = 0;
	}

	public void CollectMiniOrbs (int miniOrbCount) {
		this.MiniOrbCount += miniOrbCount;
	}

	public bool TrySpendMiniOrbs (int miniOrbCount) {
		bool returnValue = HasSufficientMiniOrbs(miniOrbCount);
		if (returnValue) {
			this.MiniOrbCount -= miniOrbCount;
		}
		return returnValue;
	}

	public bool HasSufficientMiniOrbs (int miniOrbCount) {
		return this.MiniOrbCount >= miniOrbCount;
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
