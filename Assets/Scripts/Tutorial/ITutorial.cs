/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public interface ITutorial: IJSONDeserializable, IJSONSerializable {
	ITutorialStep CurrentStep {get;}
	int StepCount {get;}
	int StepsRemaining {get;}
	string Name {get;}
	TutorialStatus Stats {get;}

	void Begin();
	void Complete();
	void Suspend();
	void Resume();
	void AddStep(ITutorialStep step);
	void AddStep(ITutorialStep step, int index);
	void RemoveStep(ITutorialStep step);
	void RemoveStep(int index);
}
