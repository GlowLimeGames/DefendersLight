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
	static string WorldStateFilePath {
		get {
			return Path.Combine(Application.persistentDataPath, WORLD_STATE_FILE_NAME);
		}
	}

	WorldState currentWorldState;

	public static IDataController Instance;

	#region World State

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

	public void Save(IData data) {

	}

	public void SaveSesion (ISessionData session) {

	}

	public void SaveJSON(string fileName, string jsonText) {

	}

	public string RetrieveJSON(string fileName) {
		throw new System.NotImplementedException();
	}

	public void Reset () {
		ResetWorldState();
	}

	void ResetWorldState () {
		currentWorldState = new WorldState(WorldStateFilePath);
		SaveWorldState();
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
		SingletonUtil.TryInit(ref Instance, this, gameObject);
	}

	protected override void FetchReferences () {

	}

	protected override void CleanupReferences () {
		Instance = null;
	}

	protected override void HandleNamedEvent (string eventName) {

	}
}
