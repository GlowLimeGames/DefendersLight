public interface IMapPath {
     IMapLocation[] Get();
     void SetOrigin(IMapLocation location);
     void SetDestination(IMapLocation location);
     void AvoidLocation(IMapLocation location);
     void IncludeLocation(IMapLocation location);
     void Recalculate();
}
