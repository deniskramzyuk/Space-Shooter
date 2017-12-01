using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByRestart : MonoBehaviour
{

    public GameObject GameController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
                if (GameController.GetComponent<GameOver>().isGameOver)
                {
                    Destroy(gameObject);
                }
    }


    public void setGameController(GameObject gameObject)
    {
        GameController = gameObject;
    }
}
