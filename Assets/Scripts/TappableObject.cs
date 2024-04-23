using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappableObject : MonoBehaviour
{
    public float beat;
    public bool didHit = false;
    public bool active = true;
    public KeyCode key;


    void Awake()
    {
        Activate();
    }

    public void Activate()
    {
        EventManager.StartListening(key.ToString(), CheckTap);
        active = true;
    }

    public void Deactivate()
    {
        EventManager.StopListening(key.ToString(), CheckTap);
        active = false;
    }

    private void CheckTap()
    {
        if (Conductor.instance.checkBeat(beat))
        {
            // Stop listening once you get a hit
            Deactivate();
            didHit = true;
            Debug.Log("["+ key.ToString()+"] Tapped at: " + Conductor.instance.getSongPosition().ToString());
        }
        else
        {
            Debug.Log("["+key.ToString()+"] Tapped at: " + Conductor.instance.getSongPosition().ToString());
        }
    }
}
