/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of the class that controls all the game's animations
 */

public interface IAnimationController {
	void Play(string animationName);
	void Play(IAnimation animation);
	void Play(IWorldObject worldObject, IWorldAnimation animation);
	void Play(IUIElement uiElement, IUIAnimation animation);
	void Play(IParticleAnimation animation);
	void Pause(string animationName);
	void Pause(IAnimation animation);
	void Stop(string animationName);
	void Stop(IAnimation animation);
	void Seek(string animationName, float time);
	void Seek(IAnimation animation, float time);
	void PlayAll();
	void PauseAll();
	void StopAll();
}
