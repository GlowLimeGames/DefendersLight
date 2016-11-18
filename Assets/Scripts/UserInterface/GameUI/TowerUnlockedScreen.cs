using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TowerUnlockedScreen : UIController {

    public   static bool towerUnlocked;
    public static TowerUnlockedScreen Instance;
    public GameObject newCanvas;
    public Text text;
    public static string textToDisplay;
    public int secondsToWait;

	// Use this for initialization
	void Start () {
        towerUnlocked = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(towerUnlocked){
            newCanvas.SetActive(true);
            towerUnlocked = false;
            toggleScreen();
        }
	}

    public void toggleScreen()
    {
        StartCoroutine(toggler()); 
    }


    IEnumerator toggler()
    {
        text.text = textToDisplay;
        yield return new WaitForSeconds(secondsToWait);
        text.text = "";
        newCanvas.SetActive(false);


        
    }

}
