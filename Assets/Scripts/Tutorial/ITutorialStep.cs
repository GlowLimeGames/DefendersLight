/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public interface ITutorialStep : IJSONDeserializable {
	int Index {get;}
	ITutorialElement[] Elements {get;}
	ITutorialStep Previous {get;}
	ITutorialStep Next {get;}

	void Begin();
	void Complete();
	void AddElement(ITutorialElement element);
	void RemoveElement(ITutorialElement element);
}
