/*
 * Author(s): Isaiah Mann
 * Description: 
 */

public static class EventType {

	#region Units Deaths

	public const string Death = "Death";
	public const string EnemyDestroyed = "EnemyDeath";
	public const string TowerDestroyed = "TowerDestroyed";

	#endregion

	#region Tower Attacks

	public const string ArchersTowerAttack = "ArchersTowerAttack";
	public const string BallistaeAttack = "BallistaeAttack";
	public const string CatapultAttack = "CatapultAttack";
	public const string FlameTowerAttack = "FlameTowerAttack";
	public const string FlameTowerStopAttack = "FlameTowerNoAttack";
	public const string HailfireArrowsAttack = "HailfireArrowsAttack";
	public const string LightningAttack = "LightningAttack";
	public const string CoreOrbAttack = "OrbAttack";

	#endregion

	#region Enemy Actions

	public const string EnemiesDealDamage = "EnemiesDealDamage";
	public const string EnemiesTakeDamage = "EnemiesTakeDamage";
	public const string LeaperJump = "LeaperJump";
	public const string ShadeHealing = "ShadeHealing";
	public const string EnemiesApproaching = "EnemiesApproaching";

	#endregion

	#region Tower Construction

	public const string BuildIlluminationTower = "BuildIllumination";
	public const string TowerBuilt = "BuildTower";
	public const string TowerCannotPlace = "TowerCannotPlace";
	public const string TowerSold = "TowerSold";
	public const string CannotPurchase = "CannotPurchase";
	public const string RefreshTowerPanel = "RefreshTowerPanel";
	public const string TowerPanelDeselected = "TowerPanelDeselected";

	#endregion

	#region Map Illumination

	public const string IlluminationOff = "IlluminationOff";
	public const string IlluminationOn = "IlluminationOn";

	#endregion

	#region Reward Moments

	public const string InGameReward = "InGameReward";
	public const string LevelUp = "LevelUp";
	public const string TowerUnlocked = "TowerUnlocked";

	#endregion

	#region Game Modes

	public const string LoadStart = "LoadStart";
	public const string LoadGameOver = "LoadGameOver";
	public const string LoadGame = "LoadGame";

	#endregion

	#region User Interface

	public const string Click = "GuiClick";

	#endregion

}
