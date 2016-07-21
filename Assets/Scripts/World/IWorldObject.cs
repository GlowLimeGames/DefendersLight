/*
 * Author: Isaiah Mann
 * Description: Basic behaviour of any object in the game world
 */

public interface IWorldObject {
	string GetID();
	void ToggleActive(bool isActive);
	IMapLocation GetLocation();
}
