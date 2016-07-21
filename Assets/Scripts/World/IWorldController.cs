public interface IWorldController : IController {
     void Create();
     // Cleans up/destroys the world
     void Teardown();
     void AddObject(IWorldObject element);
	void RemoveObject(IWorldObject element);
     IWorldObject GetObject(string id);
}
