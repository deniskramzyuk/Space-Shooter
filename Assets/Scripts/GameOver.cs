using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverText, restartText;
    [HideInInspector]
    public bool isGameOver = false;
    public GameObject player;
    private float timeR = 0f;


    private void Update()
    {
        if (isGameOver)
        {
            timeR = Time.deltaTime - timeR;
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene(0);
            if (Input.GetKeyDown(KeyCode.R) & timeR < 0.5f)
            {
                RestartGame();
            }
        }
    }




    public void Death()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        isGameOver = true;
        gameObject.GetComponent<SpawnWaves>().isAlive = false;

    }

    public void RestartGame()
    {
        GetComponent<Score>().ResetScore();
        player.GetComponent<DestroyPlayer>().resetLifes();
        gameOverText.SetActive(false);
        restartText.SetActive(false);
        GetComponent<Lifes>().updLifesText();
        player.transform.GetChild(2).gameObject.SetActive(false);
        player.transform.position = new Vector3();
        player.transform.rotation = new Quaternion();
        player.SetActive(true);
        GetComponent<SpawnWaves>().isAlive = true;
        GetComponent<SpawnWaves>().Spawn();
        Invoke("DisableGameOver", 0.5f);
    }

    void DisableGameOver()
    {
        isGameOver = false;
    }
}