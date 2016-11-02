using UnityEngine;
using System.Collections;

public class RewardScreen : MonoBehaviour {
	
    public bool doWindow0 = false;
    void DoWindow0(int windowID)
    {
        GUI.Button(new Rect(10, 30, 80, 20), "Click Me!");
    }

    void OnGUI()
    {
        doWindow0 = GUI.Toggle(new Rect(10, 10, 100, 20), doWindow0, "Window 0");
        if (doWindow0)
        {
            GUI.Window(0, new Rect(110, 10, 200, 60), DoWindow0, "Basic Window");
            StartCoroutine(Wait());            
        }

    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        doWindow0 = !doWindow0;
    }
}
