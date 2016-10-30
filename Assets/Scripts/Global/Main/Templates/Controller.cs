/*
 * Author(s): Isaiah Mann
 * Description: Meta class that all controllers inherit from (all controllers are singletons)
 */

using UnityEngine;
using UnityEngine.UI;

public abstract class Controller : MannBehaviour {
	protected WorldController world;
	protected DataController data;

	protected override void FetchReferences () {
		world = WorldController.Instance;
		data = DataController.Instance;
	}

	protected void toggleCanvasGroup (CanvasGroup canvas, bool isActive) {
		canvas.alpha = isActive ? 1 : 0;
		canvas.interactable = isActive;
		canvas.blocksRaycasts = isActive;
	}
}