/*
 * Author: Isaiah Mann
 * Description: Basic unit functionality
 */

public interface IUnit : IWorldObject, IJSONDeserializable, IJSONSerializable {
	string IType {get;}
	int IHealth{get;}
}
