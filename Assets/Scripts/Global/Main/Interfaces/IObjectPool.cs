/*
 * Author(s): Isaiah Mann
 * Description: Used to dequeue and enqueue objects in an Object Pool (enables recycling of resources)
 */

public interface IObjectPool<T> {
	T NewObject(object[] arguments);
	T CheckoutObject(object[] arguments);
	T[] CheckoutObjects(int count, object[] arguments);
	void CheckInObject(T instance, object[] arguments);
	void CheckInObjects(T[] instances, object[] arguments);
}
