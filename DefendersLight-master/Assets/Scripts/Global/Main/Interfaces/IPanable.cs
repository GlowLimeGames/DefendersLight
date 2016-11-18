/*
 * Author(s): Isaiah Mann
 * Description: Indicates and object can handle a pan
 */

using UnityEngine;

public interface IPanable {
	void HandlePan(Vector2 panDirection);
}
