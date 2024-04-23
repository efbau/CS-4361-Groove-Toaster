using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("z");
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            Debug.Log("x");
        }
    }
}
