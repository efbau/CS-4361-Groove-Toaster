using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //TODO: event handler to retrieve dspTime when AudioController plays song - at start?
    [SerializeField] private float offset;
    [SerializeField] private float bpm;
    
    private float dspTimeOnPlay; // dspTime when song is initially played
    private float beatDuration; // time duration of a beat; 60/bpm
    private float beatsPerBar;
    private float songPosition;
    private float songPositionInBeats;
    private float deltaSongPosition;
    private AudioSource musicSource;

    // Start is called before the first frame update
    private void Start() {
        //load AudioSource
        musicSource = GetComponent<AudioSource>();

        //record dspTime when song is played
        dspTimeOnPlay = (float) AudioSettings.dspTime;

        //set song params
        bpm = 72.5f;
        offset = 3.356f;
        beatDuration = 60f/bpm;
        beatsPerBar = 4f;
        
        //start music
        musicSource.Play();
    }

    //updates current song position (in beats and seconds) on every frame
    private void Update() {
        songPosition = (float) (AudioSettings.dspTime - dspTimeOnPlay) - offset;
        songPositionInBeats = songPosition/beatDuration;
    }

    public float getSongPosition() {
        return songPosition;
    }

    public float getSongPositionInBeats() {
        return songPositionInBeats;
    }

    public float getBpm() {
        return bpm;
    }
}
