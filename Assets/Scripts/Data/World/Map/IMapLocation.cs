/*
 * Author(s): Isaiah Mann
 * Description: Template behaviour and stats for a location on the map
 */

public interface IMapLocation {
	int Distance(IMapLocation otherLocation);
	int IX{get;}
	int IY{get;}
	void Set(int x, int y);
}
