
public interface IMapController {
     void Place(IWorldObject element, IMapLocation location);
     void MoveTo(IWorldObject element, IMapLocation location);
     bool TryGetPath(IWorldObject element,
		IMapLocation destination,
		out IMapPath path);

}
