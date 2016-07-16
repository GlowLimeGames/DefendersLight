using UnityEngine;
using System.Collections;

public abstract class MobileAgentBehaviour : ActiveObjectBehaviour {

    public abstract void MoveTo(MapLocation location);
}
