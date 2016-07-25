/*
 * Author(s): Isaiah Mann
 * Description: Controls the set up of the game world
 */

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
}