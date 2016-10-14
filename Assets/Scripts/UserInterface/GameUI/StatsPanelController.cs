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
	const string MINI_ORBS = "Mini Orbs";
	const string LEVEL = "Level";
	const string XP = "XP";

	[SerializeField]
	Text waveText;
	[SerializeField]
	Text enemyText;
	[SerializeField]
	Text miniOrbText;
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

	public void SetMiniOrbs (int miniOrbs) {
		miniOrbText.text = getMiniOrbText(miniOrbs);
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

	string getMiniOrbText (int miniOrbs) {
		return string.Format("{0}: {1}", MINI_ORBS, miniOrbs);
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
