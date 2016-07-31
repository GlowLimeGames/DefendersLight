/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of a path through the map (a mobile unit will typically have a path that it's following)
 */

public interface IMapPath {
	IMapLocation[] Steps {get;}
    void SetOrigin(IMapLocation location);
    void SetDestination(IMapLocation location);
    void AvoidLocation(IMapLocation location);
    void IncludeLocation(IMapLocation location);
    void Recalculate();
}
