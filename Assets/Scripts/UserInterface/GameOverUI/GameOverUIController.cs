/*
 * Author(s): Isaiah Mann
 * Description: Controls the game over UI
 */

using UnityEngine;
using UnityEngine.UI;

public class GameOverUIController : MannBehaviour, IUIController {
	[SerializeField]
	Text enemiesKilled;
	[SerializeField]
	Text wavesSurvivied;

	protected override void FetchReferences () {
		if (DataController.Instance) {
			enemiesKilled.text = string.Format(enemiesKilled.text, DataController.Instance.EnemiesKilled);
			wavesSurvivied.text = string.Format(wavesSurvivied.text, DataController.Instance.WavesSurvivied);
			DataController.Instance.ResetGame();
		}
	}

	protected override void SetReferences () {

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

	public void LoadStartScreen () {
		SceneController.LoadStart();
	}

	public void LoadGame () {
		SceneController.LoadGame();
	}
}