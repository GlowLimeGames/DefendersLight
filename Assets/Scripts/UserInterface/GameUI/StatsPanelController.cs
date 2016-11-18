/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsPanelController : UIController {
	public static StatsPanelController Instance;
	Color defaultTextColor = Color.white;
	const string WAVE = "Wave";
	const string ENEMIES = "Enemies";
	const string MANA = "Mana: ";
	const string LEVEL = "Level";
	const string XP = "XP";

	[Header("Refs")]
	[SerializeField]
	Text waveText;
	[SerializeField]
	Text enemyText;
	[SerializeField]
	UIAnimatedCount manaText;
	[SerializeField]
	Text levelText;
	[SerializeField]
	Text xpText;
	[SerializeField]
	Image manaIcon;

	[Header("Tuning")]
	[SerializeField]
	float manaCountTime = 0.5f;
	[SerializeField]
	Color manaColor = Color.cyan;
	[SerializeField]
	Color loseManaColor = Color.red;

	int mostRecentManaValue = 0;

	public void SetManaTextColor (Color color) {
		manaText.SetColor(color);
		manaIcon.color = color;
	}

	public void ResetManaTextColor () {
		SetManaTextColor(defaultTextColor);
	}

	public void SetWave (int waveIndex) {
		waveText.text = getWaveText(waveIndex);
	}

	public void SetEnemies (int enemiesAlive) {
		enemyText.text = getEnemyText(enemiesAlive);
	}

	public void SetMana (int mana) {
		manaText.StartCount(mana, manaCountTime, mostRecentManaValue <= mana ? manaColor : loseManaColor);
		mostRecentManaValue = mana;
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
		manaText.SetPrefixText(MANA);
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		SetMana(DataController.Instance.Mana);
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
		SingletonUtil.TryCleanupSingleton(ref Instance, this);
	}
}
