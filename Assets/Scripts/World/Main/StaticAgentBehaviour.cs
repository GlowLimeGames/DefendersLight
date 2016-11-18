/*
 * Author(s): Isaiah Mann
 * Description: Template actions for non-moving objects in the game world that can interact w/ other active objects
 */

using UnityEngine;
using System.Collections;

public abstract class StaticAgentBehaviour : ActiveObjectBehaviour {
	protected MapTileBehaviour tile;

	public void SetTile (MapTileBehaviour tile) {
		this.tile = tile;
	}

	public override void Destroy () {
		base.Destroy ();
		if (tile) {
			this.tile.RemoveAgent();
			this.tile = null;
		}
	}
}
