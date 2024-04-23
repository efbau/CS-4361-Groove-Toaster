using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputManager : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            //Debug.Log("z");
            EventManager.TriggerEvent(KeyCode.Z.ToString());
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            //Debug.Log("x");
            EventManager.TriggerEvent(KeyCode.X.ToString());
        }
    }
}
