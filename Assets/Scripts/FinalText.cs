using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalText : MonoBehaviour {
    public TMP_Text perfect;
    public TMP_Text good;
    public TMP_Text ok;
    public TMP_Text miss;
    public TMP_Text score;

    // Start is called before the first frame update
    void Start() {
        int p = Conductor.instance.perfect;
        int g = Conductor.instance.good;
        int o = Conductor.instance.ok;
        int m = (325 - Conductor.instance.perfect - Conductor.instance.good - Conductor.instance.ok);
        int s = (p * 100 + g * 75 + o * 50 + m * -10);


        perfect.SetText("Perfect: " + p);
        good.SetText("Good: " + g);
        ok.SetText("Ok: " + o);
        miss.SetText("Miss: " + m);
        score.SetText("Score: " + s);
    }

    // Update is called once per frame
    void Update() {

    }
}
