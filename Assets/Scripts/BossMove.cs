using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossMove : MonoBehaviour
{

    public float speed;
    private Vector3 move;

    void Start()
    {
        move = (new Vector3(-1, 0f, 0f)).normalized * speed; 
        GetComponent<Rigidbody>().velocity = move;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            if (gameObject.GetComponent<BossDestroy>().GameController.GetComponent<GameOver>().isGameOver)
            {
                Destroy(gameObject);
            }

        if (gameObject.transform.position.x > 2.6f)
        {

            GetComponent<Rigidbody>().velocity = (new Vector3(-1, 0f, 0f)).normalized * speed;

        }
        if (gameObject.transform.position.x < -2.6f)
        {
            GetComponent<Rigidbody>().velocity = (new Vector3(1, 0f, 0f)).normalized * speed;
        }
    }
}
