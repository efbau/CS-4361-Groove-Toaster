using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _title;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        IntEventManager.StartListening("updateScore", UpdateScore);
        EventManager.StartListening("reset", Reset);
        UpdateText();
    }

    private void Reset()
    {
        score = 0;
        UpdateText();
    }

    private void UpdateScore(int val)
    {
        score += val;
        UpdateText();
    }

    private void UpdateText()
    {
        _title.text = "SCORE: " + score.ToString();
    }

}
