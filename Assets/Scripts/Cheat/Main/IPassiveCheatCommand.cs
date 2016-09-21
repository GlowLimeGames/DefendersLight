/*
 * Author(s): Isaiah Mann
 * Description: For cheats that are persistent. (e.g. invicibility). 
 * Notes: Cheats should not persist between game sessions (do not need to be serialized)
 */

public interface IPassiveCheatCommand : ICheatCommand {
	void Kill();
}
