/*
 * Author(s): Isaiah Mann
 * Description: Handles setting and running cheats
 */

using System.Collections.Generic;
using System.Linq;

public class CheatController : Controller, ICheatController {
	const string MINI_ORB_CHEAT_ID = "Increase Mini Orbs";

	public int MiniOrbCheatIncreaseAmount = 10000;
	ICheatCommand miniOrbCheat = null;
	public List<ICheatCommand> cheats {get; private set;}

	// Cheats that are currently affecting the game state
	IPassiveCheatCommand[] runningCheats = null;
	public IPassiveCheatCommand[] IRunningCheats { 
		get {
			return runningCheats;
		}
	}

	public void HealAllTowers() { 
		WorldController.Instance.HealAllTowers ();
	}
    
    public void KillAllEnemies() {
        WorldController.Instance.KillAllEnemies();
    }

    public void GodMode() {
        WorldController.Instance.ToggleGodMode();
    }

    public void setWave(int waveIndex) {
        WorldController.Instance.setWave(waveIndex);
    }

    public void DestroyAllTowers() {
        WorldController.Instance.DestroyAllTowers();
    }

	public void RunMiniOrbCheat () {
		Run(miniOrbCheat);
	}

	public void Run(ICheatCommand command) {
		command.Run();
	}

	public ICheatCommand GetCheat(string id) {
		return cheats.Find(cheat => cheat.ID == id);
	}

	protected override void SetReferences () {
		cheats = new List<ICheatCommand>();
	}

	protected override void FetchReferences () {
		miniOrbCheat = new MiniOrbCheat(MINI_ORB_CHEAT_ID, MiniOrbCheatIncreaseAmount, WorldController.Instance);
		cheats.Add(miniOrbCheat);
	}

	protected override void CleanupReferences () {

	}

	protected override void HandleNamedEvent (string eventName) {

	}

	#region JSON

	public void DeserializeFromJSON(string jsonText) {

	}

	public void DeserializeFromJSONAtPath(string jsonPath) {

	}

	#endregion
}