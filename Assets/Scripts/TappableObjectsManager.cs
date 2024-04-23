using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TappableObjectsManager : MonoBehaviour
{
    public TappableObject[] tappableObjects;
    public List<float> beats;
    // Start is called before the first frame update
    void Start()
    {
        ResetTappableObjects();
    }

    public void ResetTappableObjects()
    {
        float thisBeat = Conductor.instance.getSongPositionInBeats();

        int index = FindNext(thisBeat);

        for (int i = 0; i < tappableObjects.Length; i++)
        {
            if (tappableObjects[i].active)
                tappableObjects[i].Deactivate();
        }

        tappableObjects[index].Activate();
    }

    public int FindNext(float currentBeat)
    {
        int start = beats.FindIndex(0, beats.Count, u => u == currentBeat);

        if (start + 1 < beats.Count) {
            return start + 1;
        }
        Debug.LogError("End of list.");
        return 0;
    }
}
