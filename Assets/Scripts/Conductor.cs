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
    private float okThreshold;
    private float goodThreshold;
    private float perfectThreshold;
    private bool paused = false;

    private static Conductor _instance;

    public static Conductor instance { get { return _instance; } }
    private void Awake() {
        //load AudioSource
        musicSource = GetComponent<AudioSource>();

        //record dspTime when song is played
        dspTimeOnPlay = (float)AudioSettings.dspTime;

        //set song params
        bpm = 72.5f;
        offset = 3.356f;
        beatDuration = 60f / bpm;
        beatsPerBar = 4f;

        okThreshold = 0.7f;
        goodThreshold = 0.4f;
        perfectThreshold = 0.1f;

        EventManager.StartListening("reset", Reset);
        EventManager.StartListening("pause", Pause);

        //set up instance
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    private void Start() {
        //start music
        musicSource.Play();
    }

    //updates current song position (in beats and seconds) on every frame
    private void Update() {
        songPosition = (float)(AudioSettings.dspTime - dspTimeOnPlay) - offset;
        songPositionInBeats = songPosition / beatDuration;
    }

    private void Reset()
    {
        musicSource.Stop();
        musicSource = GetComponent<AudioSource>();
        dspTimeOnPlay = (float)AudioSettings.dspTime;
        if (paused)
        {
            EventManager.StopListening("unpause", Pause);
            EventManager.StartListening("pause", Pause);
            paused = false;
        }
        musicSource.Play();
    }

    private void Pause()
    {
        paused = true;
        musicSource.Pause(); 
        EventManager.StopListening("pause", Pause);
        EventManager.StartListening("unpause", UnPause);
    }
    private void UnPause()
    {
        paused = false;
        musicSource.Play();
        EventManager.StopListening("unpause", UnPause);
        EventManager.StartListening("pause", Pause);
    }

    public float getSongPosition() {
        return songPosition;
    }

    public float getSongPositionInBeats() {
        return songPositionInBeats;
    }

    public float getBeatFromSongPosition(float pos)
    {
        return (pos / 1000f - offset) / beatDuration;
    }

    public float getBpm() {
        return bpm;
    }

    public bool checkBeat(float beat)
    {
        // Alternatively instead of returning a bool we can return the # of points
        if (Mathf.Abs(songPositionInBeats - beat) < okThreshold) {
            if (Mathf.Abs(songPositionInBeats - beat) < goodThreshold)
            {
                if (Mathf.Abs(songPositionInBeats - beat) < perfectThreshold)
                {
                    Debug.Log("Perfect!");
                }
                else if (songPositionInBeats - beat < 0) {
                    Debug.Log("Good - Early!");
                }
                else { Debug.Log("Good - Late!"); }
            }
            else if (songPositionInBeats - beat < 0)
            {
                Debug.Log("OK - Early!");
            }
            else { Debug.Log("OK - Late!"); }
            return true;
        }
        else if (songPositionInBeats - beat < 0)
        {
            Debug.Log("Miss - Early!");
        }
        else { Debug.Log("Miss - Late!"); }
        return false;
    }
}
