/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsPanelController : MannBehaviour, IUIController {
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

	protected override void FetchReferences () {

	}

	protected override void SetReferences () {
		SingletonUtil.TryInit(ref Instance, this, gameObject);
	}

	protected override void HandleNamedEvent (string eventName) {

	}

	protected override void CleanupReferences () {
		Instance = null;
	}

	public void AddElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void RemoveElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void ShowElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public void HideElement(IUIElement element) {
		throw new System.NotImplementedException();
	}

	public IUIElement GetElementByID(string id) {
		throw new System.NotImplementedException();
	}

	public IUIElement GetParent (IUIElement element) {
		throw new System.NotImplementedException();
	}

	public IUIElement[] GetChildren (IUIElement element) {
		throw new System.NotImplementedException();
	}
}
