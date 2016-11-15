/*
 * Author(s): Isaiah Mann
 * Description: Used to load and save data
 */

using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class DataController : Controller, IDataController {
	public TuningController tuning {get; private set;}
	EventActionInt levelUp;
	EventActionInt earnXP;
	public int StartingMana = 100;
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
	public PlayerData IPlayer {
		get {
			return currentPlayerData;
		}
	}

	WorldState currentWorldState;
	PlayerData currentPlayerData;

	public static DataController Instance;

	public LinearEquation XPEquation = new LinearEquation(200, 100);

	#region Player Data

	public PlayerData LoadPlayerData () {
		BinaryFormatter binaryFormatter = new BinaryFormatter();
		FileStream file;
		try {
			file = File.Open(PlayerDataFilePath, FileMode.Open);
			currentPlayerData = (PlayerData) binaryFormatter.Deserialize(file);
			file.Close();
		} catch {
			currentPlayerData = new PlayerData(PlayerDataFilePath);
		}
		currentPlayerData.SetXPEquation(XPEquation);
		return currentPlayerData;

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
	public int PlayerLevel {
		get {
			return currentPlayerData.ILevel;
		}
	}
    public void LevelUpCheat() {
        currentPlayerData.LevelUpCheat();
    }
	public int XP {
		get {
			return currentPlayerData.IXP;
		}
	}

	// The total amount of data needed to level up
	public int XPForLevel {
		get {
			return currentPlayerData.IXPForLevel;
		}
	}

	public int HighestWave {
		get {
			return currentPlayerData.IHighestWave;
		}
	}
    
	public void EarnXP (int xpEarned) {
		currentPlayerData.EarnXP(xpEarned);
		callOnXPEarned(xpEarned);
		if (currentPlayerData.ReadyToLevelUp()) {
			callOnLevelUp(currentPlayerData.LevelUp());
		}
	}


	public void AutoLevelUp () {
		currentPlayerData.LevelUpCheat();
	}
		
	public void SubscribeToOnLevelUp (EventActionInt onLevelUp) {
		levelUp += onLevelUp;
	}

	public void UnsubscribeFromOnLevelUp (EventActionInt onLevelUp) {
		levelUp -= onLevelUp;
	}

	void callOnLevelUp (int newLevel) {
		if (levelUp != null) {
			levelUp(newLevel);
		}
	}

	public void SubscribeToOnXPEarned (EventActionInt onXPEarned) {
		earnXP += onXPEarned;
	}

	public void UnsubscribeFromOnXPEarned (EventActionInt onXPEarned) {
		earnXP -= onXPEarned;
	}

	void callOnXPEarned (int xpEarned) {
		if (this.earnXP != null) {
			this.earnXP(xpEarned);
		}
	}

	public bool CheckToUpdateHighestWave (int waveReached) {
		if (currentPlayerData.NewHighestWave(waveReached)) {
			currentPlayerData.UpdateHighestWave(waveReached);
			return true;
		} else {
			return false;
		}
	}

	public bool CheckToUpdateHighestWave () {
		return CheckToUpdateHighestWave(currentWorldState.CurrentWave);
	}

	#endregion

	#region World State

	public int Mana {
		get {
			return currentWorldState.IMana;
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
			currentWorldState = new WorldState(WorldStateFilePath, StartingMana);
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
			currentWorldState = new WorldState(WorldStateFilePath, StartingMana);
		}
		binaryFormatter.Serialize(file, currentWorldState);
		file.Close();
	}

	public void CollectMana (int mana) {
		this.currentWorldState.CollectMana(mana);
	}

	public bool TrySpendMana (int mana) {
		return this.currentWorldState.TrySpendMana(mana);
	}

	public bool HasSufficientMana (int mana) {
		return this.currentWorldState.HasSufficientMana(mana);
	}

	public void NextWave () {
		this.currentWorldState.NextWave();
	}

	public void UpdateEnemiesKilled (int deltaEnemiesKilled) {
		this.currentWorldState.UpdateEnemiesKilled(deltaEnemiesKilled);
	}

	// Just meant for record keeping: Does not actually reward the player with more XP
	public void UpdateXPEarned (int deltaXP) {
		this.currentWorldState.UpdateXPEarned(deltaXP);
	}

	public void GiveReward (RewardAmount reward) {
		CollectMana(reward.Mana);
		EarnXP(reward.XP);
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

	public void ResetWorld () {
		CheckSaveDirectory();
		ResetWorldState();
	}

	public void LoadGame () {
		CheckSaveDirectory();
		LoadWorldState();
		LoadPlayerData();
		setPlayerLevel();
	}

	void setPlayerLevel () {
		callOnLevelUp(PlayerLevel);
	}

	public void SaveGame () {
		CheckSaveDirectory();
		SaveWorldState();
		SavePlayerData();
	}

	void ResetWorldState () {
		currentWorldState = new WorldState(WorldStateFilePath, StartingMana);
		SaveWorldState();
	}

	public void ResetPlayerData () {
		currentPlayerData = new PlayerData(PlayerDataFilePath);
		currentPlayerData.SetXPEquation(XPEquation);
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
			tuning = GetComponent<TuningController>();
		}
	}

	protected override void FetchReferences () {

	}

	protected override void CleanupReferences () {
		SingletonUtil.TryCleanupSingleton(ref Instance, this);
	}

	protected override void HandleNamedEvent (string eventName) {
		if (eventName == EventType.LoadStart) {
			ResetWorldState();
		}
	}
}
