using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCalls : MonoBehaviour
{
    bool isPaused = false;
    public void tapReset()
    {
        EventManager.TriggerEvent("reset");
    }

    public void tapPause()
    {
        isPaused = !isPaused;
        if (isPaused)
            EventManager.TriggerEvent("pause");
        else
            EventManager.TriggerEvent("unpause");
    }

    public void tapExit()
    {
        EventManager.TriggerEvent("exit");
    }
}
