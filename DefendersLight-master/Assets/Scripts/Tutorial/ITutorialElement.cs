/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public interface ITutorialElement : IJSONDeserializable {
	ITutorialElement[] Siblings {get;}
	ITutorialStep Parent {get;}

	void Show();
	void Hide();
	void Rest();
	void SetParent(ITutorialStep step);
}
