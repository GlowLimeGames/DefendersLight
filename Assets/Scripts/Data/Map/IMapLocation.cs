public interface IMapLocation {
	int Distance(IMapLocation otherLocation);
	int GetX();
	int GetY();
	void Set(int x, int y);
}
