public interface IWorldController {
    void Create();
    void Teardown();
    void AddObject(IWorldObject element);
	void RemoveObject(IWorldObject element);
    IWorldObject GetObject(string id);
}
