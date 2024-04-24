using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappableObject : MonoBehaviour
{
    public float beat;
    public bool didHit = false;
    public bool active = true;
    public KeyCode key;

    public void Initialize(float beat, bool active = false, KeyCode key = KeyCode.Space)
    {
        this.beat = beat;
        this.active = active;
        this.key = key;
    }

    void Awake()
    {
       if (active)
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
            // Display hit animation
            //Debug.Log("["+ key.ToString()+"] Tapped at: " + Conductor.instance.getSongPosition().ToString());
        }
        else
        {
            //Debug.Log("["+key.ToString()+"] Tapped at: " + Conductor.instance.getSongPosition().ToString());
            // Display miss animation
        }
        NoteManager.instance.ResetNotes();
    }
}
