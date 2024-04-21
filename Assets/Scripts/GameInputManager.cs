using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {
    private void Update() {
        if (Input.GetKey(KeyCode.Z)) {
            Debug.Log("z");
        }

        if (Input.GetKey(KeyCode.X)) {
            Debug.Log("z");
        }
    }
}
