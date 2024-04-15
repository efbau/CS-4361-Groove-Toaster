using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour {
    public void Exit() {
        SceneManager.LoadSceneAsync(0);
    }

    public void Pause() {
        Time.timeScale = 0;
    }

    public void Reset() {
        SceneManager.LoadSceneAsync(1);
    }
}
