/*
 * Author(s): Isaiah Mann
 * Description: A single cheat command, some can accept custom arguments)
 */

public interface ICheatCommand: IJSONDeserializable {
	string ID {
		get;
	}
	bool AcceptsCustomArguments {
		get;
	}
	void Run();
	void SetArguments(object[] arguments);
}
