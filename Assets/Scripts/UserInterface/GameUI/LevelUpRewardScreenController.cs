using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class LevelUpRewardScreenController : UIController {

    public GameObject newCanvas;
    public Text text;

    public static bool Leveled;    

    void Start()
    {
        newCanvas.SetActive(false);
        //text.text = "";
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
        text.text = "LEVEL UP!";
        yield return new WaitForSeconds(5);
        text.text = "";
        newCanvas.SetActive(false);
    }

}
