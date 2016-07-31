/*
 * Author(s): Isaiah Mann
 * Description: Controls the set up of the game world
 */
using UnityEngine;

public class WorldController : MannBehaviour, IWorldController {
	public void Create() {

	}

	// Cleans up/destroys the world
	public void Teardown() {

	}

	public void AddObject(IWorldObject element) {

	}

	public void RemoveObject(IWorldObject element) {

	}

	public IWorldObject GetObject(string id) {
		throw new System.NotImplementedException();
	}

	protected override void SetReferences () {

	}

	protected override void FetchReferences () {

	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent (string eventName) {

	}
		
	#region JSON Serialization
	public string SerializeAsJSON() {
		throw new System.NotImplementedException();
	}

	public void SaveAsJSONToPath(string path) {
		throw new System.NotImplementedException();
	}

	public void DeserializeFromJSON(string jsonText) {
		throw new System.NotImplementedException();
	}

	public void DeserializeFromJSONAtPath(string jsonPath) {
		throw new System.NotImplementedException();
	}
	#endregion

	#region Input Handling
	public void HandleZoom (float zoomFactor) {
		throw new System.NotImplementedException();
	}

	public void HandlePan (Vector2 panDirection) {
		throw new System.NotImplementedException();
	}
	#endregion
}