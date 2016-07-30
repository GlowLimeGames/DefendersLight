/*
 * Author(s): Isaiah Mann
 * Description: Template behaviour and stats for a location on the map
 */

public interface IMapLocation {
	int Distance(IMapLocation otherLocation);
	int GetX();
	int GetY();
	void Set(int x, int y);
}
