using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour {
    private bool paused = false;

    private void Start()
    {
        EventManager.StartListening("pause", Pause);
    }
    private void Pause()
    {
        paused = true;
        EventManager.StopListening("pause", Pause);
        EventManager.StartListening("unpause", UnPause);
    }
    private void UnPause()
    {
        paused = false;
        EventManager.StopListening("unpause", UnPause);
        EventManager.StartListening("pause", Pause);
    }


    private void Update() {
        if (!paused)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                //Debug.Log("z");
                EventManager.TriggerEvent(KeyCode.Z.ToString());
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                //Debug.Log("x");
                EventManager.TriggerEvent(KeyCode.X.ToString());
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("Space");
                EventManager.TriggerEvent(KeyCode.Space.ToString());
            }
        }
    }
}
