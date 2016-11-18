using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LevelUpRewardScreenController : UIController {

    public GameObject newCanvas;
    public Text text;
    public string textToDisplay;
    public int secondsToWait = 5;

    public static LevelUpRewardScreenController Instance;    

	protected override void SetReferences () {
		base.SetReferences ();
		Instance = this;
	}

    protected override void FetchReferences () {
        newCanvas.SetActive(false);        
        
    }

    public void toggleScreen() {
        StartCoroutine(toggler());               
    }

    IEnumerator toggler() {
        newCanvas.SetActive(true);
        text.text = textToDisplay;
        yield return new WaitForSeconds(secondsToWait);
        text.text = "";
        newCanvas.SetActive(false);
    }

}
