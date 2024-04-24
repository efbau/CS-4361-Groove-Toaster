using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float lastBeat = 0f;
    // Start is called before the first frame update
    void Start() {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        float currentBeat = Conductor.instance.getSongPosition();
        float elapsed = currentBeat - lastBeat;

        if (elapsed > 0) {
            transform.position += transform.forward * elapsed;
        }

        lastBeat = currentBeat;
    }

    //public float speed = 5f;

    //void Update() {
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //}
}
