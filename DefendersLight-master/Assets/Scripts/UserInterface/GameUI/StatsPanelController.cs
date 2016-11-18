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

	[SerializeField]
	Text waveText;
	[SerializeField]
	Text enemyText;
	[SerializeField]
	Text miniOrbText;

	public void SetWave (int waveIndex) {
		waveText.text = getWaveText(waveIndex);
	}

	public void SetEnemies (int enemiesAlive) {
		enemyText.text = getEnemyText(enemiesAlive);
	}

	public void SetMiniOrbs (int miniOrbs) {
		miniOrbText.text = getMiniOrbText(miniOrbs);
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
		
	protected override void SetReferences () {
		base.SetReferences();
		SingletonUtil.TryInit(ref Instance, this, gameObject);
	}

	protected override void CleanupReferences () {
		base.CleanupReferences();
		SingletonUtil.TryCleanupSingleton(ref Instance, this);
	}
}
