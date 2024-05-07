using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score_text;
    public int score = 0;

    void Update()
    {
        // Update score text
        score_text.text = "Score: " + score;
    }
}

