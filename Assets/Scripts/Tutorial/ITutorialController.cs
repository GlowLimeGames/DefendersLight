/*
 * Author(s): Isaiah Mann
 * Description: Describes the expected behaviour of the tutorial system
 */

using System.Collections.Generic;

public interface ITutorialController {
	ITutorial[] AllTutorials {get;}
	Dictionary<TutorialStatus, ITutorial> TutorialsByStatus {get;}

	void Begin(string name);
	void Begin(ITutorial tutorial);
	void Complete(ITutorial tutorial);
	void Resume(ITutorial tutorial);
	void Suspend(ITutorial tutorial);
	TutorialStatus GetStatus(ITutorial tutorial);
}
