/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of objects in the game logic that can dynamically allocate and deallocate gameobjects
 */

using UnityEngine;

public interface IGameObjectLink {
	void InitializeGameObject(GameObject fromObject);
	GameObject ReleaseGameObject();
}
