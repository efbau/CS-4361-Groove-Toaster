using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    [SerializeField] private int fps = 60;
    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = fps;
    }

    private void Update() {
        if(Application.targetFrameRate != fps) {
            Application.targetFrameRate = fps;
        }
    }

    public int getFPSLimit() {
        return fps;
    }
}
