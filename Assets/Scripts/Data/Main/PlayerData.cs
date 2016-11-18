/*
 * Author(s): Isaiah Mann
 * Description: Stores data about the player
 */

[System.Serializable]
public class PlayerData : IPlayerData {
	MathEquation xpEquation;

	int _xp;
	int _level;
	int _highestWave;
	string _filePath;
	public int IXP {
		get {
			return _xp;
		}
	}
	public int ILevel{
		get {
			return _level;
		}
	}
	public int IXPForLevel {
		get {
			if (xpEquation != null) {
				return xpEquation.Calculate(_level);
			} else {
				return 0;
			}
		}
	}

	public int IHighestWave {
		get {
			return _highestWave;
		}
	}
	public string IFilePath {
		get {
			return _filePath;
		}
		set {
			setFilePath(value);
		}
	}

	public PlayerData (string filePath) {
		setFilePath(filePath);
		Reset();
	}

	public PlayerData (string filePath, int xp, int level, int highestWave) {
		setFilePath(filePath);
		this._xp = xp;
		this._level = level;
		this._highestWave = highestWave;
	}

	public void Reset () {
		this._xp = 0;
		this._level = 1;
		this._highestWave = 0;
	}

	public void SetXPEquation (MathEquation equation) {
		this.xpEquation = equation;
	}

	public void EarnXP (int xpEarned) {
		this._xp += xpEarned;
	}

	// Returns new player level
	public int LevelUp () {
		if (ReadyToLevelUp()) {
			this._xp -= IXPForLevel;
			this._level++;
		}
        
        TowerController.Instance.compareTowerLevels();

        return this._level;
	}

    public void LevelUpCheat() {
        this._level++;
		this._xp = 0;
        
        TowerController.Instance.compareTowerLevels();
    }

	public bool ReadyToLevelUp () {
		return IXPForLevel <= this._xp;
	}

	public bool NewHighestWave (int waveReached) {
		return waveReached > this._highestWave;
	}

	public void UpdateHighestWave (int waveReached) {
		this._highestWave = waveReached;
	}

	void setFilePath (string filePath) {
		this._filePath = filePath;
	}
}
