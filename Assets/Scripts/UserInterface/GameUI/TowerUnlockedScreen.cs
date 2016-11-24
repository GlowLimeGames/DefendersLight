/*
 * Author(s): Brandon Huici, Isaiah Mann
 * Description: DIsplays Tower Unlocked Message
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TowerUnlockedScreen : UIController {
    public GameObject newCanvas;
    public Text text;
    public static string textToDisplay;
    public int secondsToWait;

	void playTowerUnlockedMoment () {
		newCanvas.SetActive(true);
		toggleScreen();
	}

    void toggleScreen() {
        StartCoroutine(toggler()); 
    }


    IEnumerator toggler() {
        text.text = textToDisplay;
        yield return new WaitForSeconds(secondsToWait);
        text.text = "";
        newCanvas.SetActive(false);
    }

	protected override void HandleNamedEvent (string eventName) {
		if (eventName == EventType.TowerUnlocked) {
			playTowerUnlockedMoment();
		} else {
			base.HandleNamedEvent (eventName);
		}
	}
}
