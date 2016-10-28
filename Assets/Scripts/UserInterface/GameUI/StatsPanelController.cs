/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsPanelController : UIController {
	public static StatsPanelController Instance;

	const string WAVE = "Wave";
	const string ENEMIES = "Enemies";
	const string MANA = "Mana";
	const string LEVEL = "Level";
	const string XP = "XP";

	[SerializeField]
	Text waveText;
	[SerializeField]
	Text enemyText;
	[SerializeField]
	Text manaText;
	[SerializeField]
	Text levelText;
	[SerializeField]
	Text xpText;

	public void SetWave (int waveIndex) {
		waveText.text = getWaveText(waveIndex);
	}

	public void SetEnemies (int enemiesAlive) {
		enemyText.text = getEnemyText(enemiesAlive);
	}

	public void SetMana (int mana) {
		manaText.text = getManaText(mana);
	}

	public void SetLevel (int level) {
		levelText.text = getLevelText(level);
	}

	public void SetXP (int xpEarned, int xpForLevel) {
		xpText.text = getXPText(xpEarned, xpForLevel);
	}

	string getWaveText (int waveIndex) {
		return string.Format("{0}: {1}", WAVE, waveIndex);
	}

	string getEnemyText (int enemiesAlive) {
		return string.Format("{0}: {1}", ENEMIES, enemiesAlive);
	}

	string getManaText (int mana) {
		return string.Format("{0}: {1}", MANA, mana);
	}
		
	string getLevelText (int level) {
		return string.Format("{0}: {1}", LEVEL, level);
	}

	string getXPText (int xpEarned, int totalLevelXP) {
		return string.Format("{0}: {1}/{2}", XP, xpEarned, totalLevelXP);
	}

	protected override void SetReferences () {
		base.SetReferences();
		SingletonUtil.TryInit(ref Instance, this, gameObject);
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
		SingletonUtil.TryCleanupSingleton(ref Instance, this);
	}
}
