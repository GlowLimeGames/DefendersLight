/**
 * Author(s): Ranjini Das
 **/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIButton : MannBehavior
{
    GameObject gameObject;
    EventController.Action action; 
    bool isDown;
    public delegate void performAction (EventController.Action action);  

    public UIButton (GameObject gameObject, EventController.Action action)
    {
        this.gameObject = gameObject;
        this.action = action; 
    }

    public void ButtonDown()
    {
        isDown = true;
        AddButtonHeldEvent(action);     
    }

    public void ButtonUp()
    {
        isDown = false;
        AddOnUpEvent(action);  
    }

    public bool IsDown()
    {
        return isDown; 
    }

    public void onClick()
    {
        AddClickEvent(); 
    }

    void AddClickEvent(EventController.Action action)
    {
        gameObject.performAction(action); 
    }

    // Called every frame the button is held down
    void AddButtonHeldEvent(EventController.Action action)
    {
        if (isDown)
        {
            AddOnDownEvent(action); 
        }
    }

    void AddOnDownEvent(EventController.Action action)
    { 
        gameObject.performAction(action); 
    }

    void AddOnUpEvent(EventController.Action action)
    {
        if (!isDown)
        {   
            gameObject.performAction(action); 
        }
    }
}