/*
 * Author(s): Isaiah Mann
 * Description: Template actions for a world objects that can move around the map
 */

using UnityEngine;
using System.Collections;

public abstract class MobileAgentBehaviour : ActiveObjectBehaviour {

    public abstract void MoveTo(MapLocation location);
}
