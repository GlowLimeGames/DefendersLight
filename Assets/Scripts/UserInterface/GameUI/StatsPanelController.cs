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

	[SerializeField]
	Text waveText;

	[SerializeField]
	Text enemyText;



	public void SetWave (int waveIndex) {
		waveText.text = getWaveText(waveIndex);
	}

	public void SetEnemies (int enemiesAlive) {
		enemyText.text = getEnemyText(enemiesAlive);
	}

	string getWaveText (int waveIndex) {
		return string.Format("{0}: {1}", WAVE, waveIndex);
	}

	string getEnemyText (int enemiesAlive) {
		return string.Format("{0}: {1}", ENEMIES, enemiesAlive);
	}

	protected override void FetchReferences () {

	}

	protected override void SetReferences () {
		SingletonUtil.TryInit(ref Instance, this, gameObject);
	}

	protected override void HandleNamedEvent (string eventName) {

	}

	protected override void CleanupReferences () {

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
