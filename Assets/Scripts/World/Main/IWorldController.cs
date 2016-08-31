/*
 * Author: Isaiah Mann
 * Description: Overwatch of the game world public functionality
 */

using UnityEngine.EventSystems;

public interface IWorldController : IController, IJSONSerializable, IJSONDeserializable, IZoomable, IPanable {
	UnityEngine.GameObject ITowerPrefab {get;}
			
	void Create();
    // Cleans up/destroys the world
    void Teardown();
    void AddObject(IWorldObject element);
	void RemoveObject(IWorldObject element);
    IWorldObject GetObject(string id);
	string GenerateID (IUnit unit);
	void HandleBeginDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel);
	void HandleDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel);
	void HandleEndDragPurchase (PointerEventData dragEvent, TowerPurchasePanel towerPanel);
}
