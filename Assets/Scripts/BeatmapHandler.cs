using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatmapHandler : MonoBehaviour {

    [SerializeField] private GameInputManager gameInputManager;

    // Start is called before the first frame update
    void Awake() {
        gameInputManager = GetComponent<GameInputManager>();
    }

    // Update is called once per frame
    void Update() {

    }
}