using UnityEngine;
using System.Collections;

public class LevelUpRewardScreenController : UIController {
    [SerializeField]
    GameObject LevelUpScreen;

    public static LevelUpRewardScreenController Instance;

    void Start()
    {
        Instantiate(LevelUpScreen);
    }

    public void toggleLevelUpScreen()
    {
        LevelUpScreen.SetActive(true);
        StartCoroutine(toggle());
    }

    IEnumerator toggle()
    {
        LevelUpScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        LevelUpScreen.SetActive(false);
    }
}
