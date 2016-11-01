/*
 * Author(s): Isaiah Mann
 * Description: Handles setting and running cheats
 */

using System.Collections.Generic;
using System.Linq;

public class CheatController : Controller, ICheatController {
	const string MINI_ORB_CHEAT_ID = "Increase Mini Orbs";
	StatsPanelController statsPanel;
	public int MiniOrbCheatIncreaseAmount = 10000; //changed
	ICheatCommand miniOrbCheat = null;
	public List<ICheatCommand> cheats {get; private set;}

	// Cheats that are currently affecting the game state
	IPassiveCheatCommand[] runningCheats = null;
	public IPassiveCheatCommand[] IRunningCheats { 
		get {
			return runningCheats;
		}
	}
    public void LevelUpCheat() {
		data.LevelUpCheat();
		statsPanel.SetLevel(data.PlayerLevel);
		statsPanel.SetXP(data.XP, data.XPForLevel);
    }

	public void HealAllTowers() { 
		world.HealAllTowers ();
	}
    
    public void KillAllEnemies() {
		world.KillAllEnemies();
    }

    public void GodMode() {
		world.ToggleGodMode();
    }

    public void setWave(int waveIndex) {
		world.setWave(waveIndex);
    }

    public void DestroyAllTowers() {
		world.DestroyAllTowers();
    }

	public void RunMiniOrbCheat () {
		Run(miniOrbCheat);
	}

	public void Run(ICheatCommand command) {
		command.Run();
	}

	public void UnlockAllTowers () {
		world.UnlockAllTowers();
	}

	public void ResetLevel () {
		data.ResetPlayerData();	
		statsPanel.SetLevel(data.PlayerLevel);
		statsPanel.SetXP(data.XP, data.XPForLevel);;
	}

	public ICheatCommand GetCheat(string id) {
		return cheats.Find(cheat => cheat.ID == id);
	}

	protected override void SetReferences () {
		cheats = new List<ICheatCommand>();
	}

	protected override void FetchReferences () {
		base.FetchReferences();
		miniOrbCheat = new MiniOrbCheat(MINI_ORB_CHEAT_ID, MiniOrbCheatIncreaseAmount, WorldController.Instance);
		cheats.Add(miniOrbCheat);
		statsPanel = StatsPanelController.Instance;
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