/*
 * Author(s): Isaiah Mann
 * Description: Used to load and save data
 */

using System.IO;
using UnityEngine;

public class DataController : Controller, IDataController {
	const string JSON_DIRECTORY = "JSON";

	public static IDataController Instance;

	public void Save(IData data) {

	}

	public void SaveSesion (ISessionData session) {

	}

	public void SaveJSON(string fileName, string jsonText) {

	}

	public string RetrieveJSON(string fileName) {
		throw new System.NotImplementedException();
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

	}

	protected override void HandleNamedEvent (string eventName) {

	}
}