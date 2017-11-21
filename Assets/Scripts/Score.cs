using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreNumber;
    private int score = 0;

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreNumber.text = score.ToString();
    }
}
