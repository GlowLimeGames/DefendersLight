/*
 * Author: Isaiah Mann
 * Description: Basic behaviour of any object in the game world
 */

public interface IWorldObject {
	string ID{get;}
	IMapLocation Location{get;}
	bool IsActive{get; set;}
}
