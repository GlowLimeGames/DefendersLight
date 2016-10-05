/*
 * Author(s): Isaiah Mann
 * Description: Used to load and save data
 */

using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class DataController : Controller, IDataController {
	const string JSON_DIRECTORY = "JSON";
	const string SAVE_DIRECTORY = "Save";
	const string WORLD_STATE_FILE_NAME = "WorldState.dat";
	const string PLAYER_DATA_FILE_NAME = "PlayerData.dat";
	static string SaveDirectory {
		get {
			return Path.Combine(Application.persistentDataPath, SAVE_DIRECTORY);
		}
	}
	static string WorldStateFilePath {
		get {
			return Path.Combine(SaveDirectory, WORLD_STATE_FILE_NAME);
		}
	}
	static string PlayerDataFilePath {
		get {
			return Path.Combine(SaveDirectory, PLAYER_DATA_FILE_NAME);
		}
	}

	WorldState currentWorldState;
	PlayerData currentPlayerData;

	public static DataController Instance;

	#region Player Data

	public PlayerData LoadPlayerData () {
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file;
		try {
			file = File.Open(PlayerDataFilePath, FileMode.Open);
			currentPlayerData = (PlayerData) binaryFormatter.Deserialize(file);
			file.Close();
			return currentPlayerData;
		} catch {
			currentPlayerData = new PlayerData(PlayerDataFilePath);
			return currentPlayerData;
		}
	}

	public void SavePlayerData () {
		SavePlayerData(currentPlayerData);
	}

	void CheckSaveDirectory () {
		if (!Directory.Exists(SaveDirectory)) {
			Directory.CreateDirectory(SaveDirectory);
		}
	}

	void SavePlayerData (PlayerData playerData) {
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file;
		try {
			file = File.Open(PlayerDataFilePath, FileMode.Open);
		} catch {
			file = File.Create(PlayerDataFilePath);
		}
		if (currentPlayerData == null) {
			currentPlayerData = new PlayerData(PlayerDataFilePath);
		}
		binaryFormatter.Serialize(file, currentPlayerData);
		file.Close();
	}

	#endregion

	#region World State

	public int MiniOrbCount {
		get {
			return currentWorldState.IMiniOrbs;
		}
	}
	public int EnemiesKilled {
		get {
			return currentWorldState.EnemiesKilled;
		}
	}
	public int WavesSurvivied {
		get {
			return currentWorldState.CurrentWave;
		}
	}
		
	public WorldState LoadWorldState () {
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file;
		try {
			file = File.Open(WorldStateFilePath, FileMode.Open);
			currentWorldState = (WorldState) binaryFormatter.Deserialize(file);
			file.Close();
			return currentWorldState;
		} catch {
			currentWorldState = new WorldState(WorldStateFilePath);
			return currentWorldState;
		}
	}

	public void SaveWorldState () {
		SaveWorldState(currentWorldState);
	}

	void SaveWorldState (WorldState worldState) {
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file;
		try {
			file = File.Open(WorldStateFilePath, FileMode.Open);
		} catch {
			file = File.Create(WorldStateFilePath);
		}
		if (currentWorldState == null) {
			currentWorldState = new WorldState(WorldStateFilePath);
		}
		binaryFormatter.Serialize(file, currentWorldState);
		file.Close();
	}

	public void CollectMiniOrbs (int miniOrbCount) {
		this.currentWorldState.CollectMiniOrbs(miniOrbCount);
	}

	public bool TrySpendMiniOrbs (int miniOrbCount) {
		return this.currentWorldState.TrySpendMiniOrbs(miniOrbCount);
	}

	public bool HasSufficientMiniOrbs (int miniOrbCount) {
		return this.currentWorldState.HasSufficientMiniOrbs(miniOrbCount);
	}
	
	public void NextWave () {
		this.currentWorldState.NextWave();
	}

	public void UpdateEnemiesKilled (int deltaEnemiesKilled) {
		this.currentWorldState.UpdateEnemiesKilled(deltaEnemiesKilled);
	}

	public void UpdateXPEarned (int deltaXP) {
		this.currentWorldState.UpdateXPEarned(deltaXP);
	}
		
	#endregion

	#region Player Data

	public int PlayerLevel {
		get {
			return currentPlayerData.ILevel;
		}
	}
	public int XP {
		get {
			return currentPlayerData.IXP;
		}
	}
	public int HighestWave {
		get {
			return currentPlayerData.IHighestWave;
		}
	}

	#endregion

	public void Save(IData data) {

	}

	public void SaveSesion (ISessionData session) {

	}

	public void SaveJSON(string fileName, string jsonText) {

	}

	public string RetrieveJSON(string fileName) {
		throw new System.NotImplementedException();
	}

	public void ResetGame () {
		CheckSaveDirectory();
		ResetWorldState();
		ResetPlayerData();
	}

	public void LoadGame () {
		CheckSaveDirectory();
		LoadWorldState();
		LoadPlayerData();
	}

	public void SaveGame () {
		CheckSaveDirectory();
		SaveWorldState();
		SavePlayerData();
	}

	void ResetWorldState () {
		currentWorldState = new WorldState(WorldStateFilePath);
		SaveWorldState();
	}

	void ResetPlayerData () {
		currentPlayerData = new PlayerData(PlayerDataFilePath);
		SavePlayerData();
	}

	// Resources is a special folder within the Unity Assets directory that you can load in files easily from at Runtime
	public string RetrieveJSONFromResources(string filePathInResources) {
		try {
			return Resources.Load<TextAsset>(Path.Combine(JSON_DIRECTORY, filePathInResources)).text;
		} catch {
			return string.Empty;
		}
	}

	public IData Load() {
		throw new System.NotImplementedException();
	}

	protected override void SetReferences () {
		if (SingletonUtil.TryInit(ref Instance, this, gameObject)) {
			LoadGame();
			DontDestroyOnLoad(gameObject);
		}
	}

	protected override void FetchReferences () {

	}

	protected override void CleanupReferences () {
		SingletonUtil.TryCleanupSingleton(ref Instance, this);
	}

	protected override void HandleNamedEvent (string eventName) {
		if (eventName == EventType.LoadStart) {
			ResetGame();
		}
	}
}
