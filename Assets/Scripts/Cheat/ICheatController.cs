/*
 * Author(s): Isaiah Mann
 * Description: Controls the in game cheats (primarily used for debugging purposes)
 */

public interface ICheatController : IController, IJSONDeserializable {
	// Cheats that are currently affecting the game state
	IPassiveCheatCommand[] RunningCheats {get;}

	void Run(ICheatCommand command);
	ICheatCommand GetCheat(string id);
}
