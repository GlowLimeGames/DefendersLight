public interface IWorldObject {
	string GetID();
	void ToggleActive(bool isActive);
	IMapLocation GetLocation();
}
