/*
 * Author(s): Isaiah Mann
 * Description: Template for the input controller (accepts and processes all touch/pointer input from the user)
 */

using UnityEngine;

public interface IInputController {
     void PointerDown(int pointerID, Vector3 pointerPosition);
     void PointerUp(int pointerID, Vector3 pointerPosition);
     void PointerDrag(int pointerID, Vector3 pointerPosition);
     Vector3 GetPointerPosition(int pointerID);
}
