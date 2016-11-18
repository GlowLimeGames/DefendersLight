using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LevelUpRewardScreenController : UIController {

    public GameObject newCanvas;
    public Text text;
    public string textToDisplay;
    public int secondsToWait = 5;

    public static bool Leveled;    

    void Start()
    {
        newCanvas.SetActive(false);        
        Leveled = false;
    }

    void Update()
    {       
        if (Leveled)
        {
            newCanvas.SetActive(true);
            Leveled = false;
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
