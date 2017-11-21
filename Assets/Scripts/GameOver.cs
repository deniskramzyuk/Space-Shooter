using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverText, restartText;
    private bool isGameOver = false;

    private void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(0);
        }
    }


    

    public void Death()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        isGameOver = true;
    }

    

}