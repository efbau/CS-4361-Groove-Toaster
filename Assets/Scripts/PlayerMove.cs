using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public static float speed = 5.0f;
    //private float lastBeat;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        EventManager.StartListening("reset", Reset);
    }

    private void Reset()
    {
        transform.position = new Vector3(0, 0, 0);
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
    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Result")) {
            SceneManager.LoadScene(2);
        }
    }
}

