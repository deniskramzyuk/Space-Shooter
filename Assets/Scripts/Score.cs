using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreNumber;
    private int score = 0;
    private int scoreLife = 0;
    public GameObject player;

    public void AddScore(int addScore)
    {
        score += addScore;
        scoreLife += addScore;
        scoreNumber.text = score.ToString();
        if (scoreLife >= 1000)
        {
            scoreLife %= 1000;
            player.GetComponent<DestroyPlayer>().addLife();
        }
    }

    public void ResetScore()
    {
        score = 0;
        scoreLife = 0;
        scoreNumber.text = "0";
    }
}
