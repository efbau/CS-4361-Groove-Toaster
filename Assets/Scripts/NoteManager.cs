using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] float beatDelay;
    public TappableObject[] tappableObjects;
    public List<float> beats;
    private static NoteManager _instance;
    public bool isDone = false; 
    public int currentNote;
    public GameObject Prefab;

    public static NoteManager instance { get { return _instance; } }

    void Start()
    {
        beatDelay = 2.2f;
        _instance = this;
        EventManager.StartListening("reset", Reset);
    }

    private void Reset()
    {
        for (int i = 0; i < tappableObjects.Length; i++)
        {
            tappableObjects[i].didHit = false;
        }
        currentNote = 0;
        ResetNotes();
    }

    public void loadNotes(float[] floatData)
    {
        beats.Clear();
        tappableObjects = new TappableObject[floatData.Length];
        for (int i = 0; i < tappableObjects.Length; i++)
        {
            float beat = Conductor.instance.getBeatFromSongPosition(floatData[i]) + beatDelay;
            beats.Add(beat);
            GameObject newNote = Instantiate(Prefab, new Vector3(0,0, beat*PlayerMove.speed), new Quaternion());
            TappableObject tappable = newNote.GetComponent<TappableObject>();
            tappable.Initialize(beat);
            tappableObjects[i] = tappable;
        }
        ResetNotes();
    }

    public void CheckForNextNote()
    {
        Debug.Log("Hit: " + currentNote.ToString());
        currentNote++;
        if (!tappableObjects[currentNote].active)
           tappableObjects[currentNote].Activate();
        currentNote++;
        if (currentNote >= tappableObjects.Length)
        {
                //End of level
                //EventManager.instance.Invoke();
        }

    }


    public void ResetNotes()
    {
        float thisBeat = Conductor.instance.getSongPositionInBeats();

        int index = FindNext(thisBeat);
        //Debug.Log("Reset: "+index.ToString());
        if (index < 0)
        {
            //End of level
            //EventManager.instance.Invoke("end");
            return;
        }


        for (int i = 0; i < tappableObjects.Length; i++)
        {
            if (tappableObjects[i].active)
                tappableObjects[i].Deactivate();
        }

        while (index < tappableObjects.Length && tappableObjects[index].didHit)
            index++;

        if (index >= tappableObjects.Length)
        {
            //End of level
            //EventManager.instance.Invoke("end");
            return;
        }
        tappableObjects[index].Activate();
        currentNote = index;
        isDone = false;
    }

    public int FindNext(float currentBeat)
    {
        int start = beats.FindIndex(0, beats.Count, u => u >= currentBeat);
        if (start < 0)
        {
            Debug.LogError("Next note not found");
        }
        return start;
    }
}
