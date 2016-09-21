/*
 * Author(s): Isaiah Mann
 * Description: Cheat to increase number of miniorbs the player has
 */

public class MiniOrbCheat : ICheatCommand {
	public string ID {
		get {
			return id;
		}
	}
	public bool AcceptsCustomArguments {
		get {
			return false;
		}
	}
	string id;
	int increaseAmount;
	WorldController controller;

	public MiniOrbCheat (string id, int increaseAmount, WorldController controller) {
		this.id = id;
		this.increaseAmount = increaseAmount;
		this.controller = controller;
	}

	public void Run () {
		controller.CollectMiniOrbs(increaseAmount);
	}

	public void SetArguments (object[] arguments) {
		if (arguments.Length >= 1) {
			try {
				this.increaseAmount = IntUtil.ParseObj(arguments[0]);
			} catch {
				UnityEngine.Debug.LogErrorFormat("Invalid argument {0}, expected integer", arguments[0]);
			}
		} else {
			UnityEngine.Debug.LogErrorFormat("Invalid number of arguments {0}", arguments.Length);
		}
	}

	#region JSON

	public void DeserializeFromJSON(string jsonText) {
		throw new System.NotImplementedException();
	}

	public void DeserializeFromJSONAtPath(string jsonPath) {
		throw new System.NotImplementedException();
	}

	#endregion
}
