using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static float speed = 5.0f;
    private float lastBeat;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        lastBeat = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*float currentBeat = Conductor.instance.getSongPosition();

        transform.position = Vector3.Lerp(
        transform.position,
        new Vector3(0, 0, currentBeat*speed),
        currentBeat - lastBeat
        );

        lastBeat = currentBeat;*/
        transform.position = new Vector3(0, 0, Conductor.instance.getSongPositionInBeats()*speed);
    }
}

