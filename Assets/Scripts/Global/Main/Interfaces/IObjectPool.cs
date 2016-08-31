/*
 * Author(s): Isaiah Mann
 * Description: Used to dequeue and enqueue objects in an Object Pool (enables recycling of resources)
 */

public interface IObjectPool<T> {
	T NewObject(params object[] arguments);
	T CheckoutObject(params object[] arguments);
	T[] CheckoutObjects(int count, params object[] arguments);
	void CheckInObject(T instance, params object[] arguments);
	void CheckInObjects(T[] instances, params object[] arguments);
}
