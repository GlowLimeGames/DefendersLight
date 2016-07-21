/*
 * Author: Isaiah Mann
 * Description: Ovewatch of the map - public functionality
 */

public interface IMapController : IController {
     void Place(IWorldObject element, IMapLocation location);
     void MoveTo(IWorldObject element, IMapLocation location);
     bool TryGetPath(IWorldObject element,
		IMapLocation destination,
		out IMapPath path);

}
