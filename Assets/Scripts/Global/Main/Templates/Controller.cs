/*
 * Author(s): Isaiah Mann
 * Description: Meta class that all controllers inherit from (all controllers are singletons)
 */

using UnityEngine;
using UnityEngine.UI;

public abstract class Controller : MannBehaviour {
	protected void toggleCanvasGroup (CanvasGroup canvas, bool isActive) {
		canvas.alpha = isActive ? 1 : 0;
		canvas.interactable = isActive;
		canvas.blocksRaycasts = isActive;
	}
}