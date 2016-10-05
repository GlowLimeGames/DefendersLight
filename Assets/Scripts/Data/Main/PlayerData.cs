/*
 * Author(s): Isaiah Mann
 * Description: Stores data about the player
 */

[System.Serializable]
public class PlayerData : IPlayerData {
	int _xp;
	int _level;
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

	public PlayerData (string filePath, int xp, int level) {
		setFilePath(filePath);
		this._xp = xp;
		this._level = level;
	}

	public void Reset () {
		this._xp = 0;
		this._level = 1;
	}

	void setFilePath (string filePath) {
		this._filePath = filePath;
	}
}
