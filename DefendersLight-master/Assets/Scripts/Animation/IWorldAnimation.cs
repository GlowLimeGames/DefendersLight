/*
 * Author(s): Isaiah Mann
 * Description: Animations that apply to World Objects (in-game objects)
 */

public interface IWorldAnimation : IAnimation {
	IWorldObject WorldObject {get;}
}
