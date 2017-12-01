using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float speed; 
    private Vector3 move;
    private float timeNewMove, timeMove = 0f;
    private bool isRight = true;

    void Start()
    {
        timeNewMove = Random.Range(1f, 2f);
        timeMove = timeNewMove;
        move = transform.forward * speed;
        GetComponent<Rigidbody>().velocity = move;
        GetComponent<DestroyByShot>().speed = move;
        int startMove = Random.Range(1, 3);
        if (startMove == 1)
            isRight = true;
        else isRight = false;

    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
            if (gameObject.GetComponent<DestroyByShot>().GameController.GetComponent<GameOver>().isGameOver)
            {
                Destroy(gameObject);
            }

        if (Time.time > timeMove || gameObject.transform.position.x > 5f || gameObject.transform.position.x < -5f)
        {
            if (gameObject.transform.position.x > 4.7f)
            {
                GetComponent<Rigidbody>().velocity = (new Vector3(-1, 0f, -1)).normalized * speed;
                isRight = true;
                timeMove = Time.time + timeNewMove;
            }
            else if (gameObject.transform.position.x < -4.7f)
            {
                GetComponent<Rigidbody>().velocity = (new Vector3(1, 0f, -1)).normalized * speed;
                isRight = false;
                timeMove = Time.time + timeNewMove;
            }

            if (isRight && Time.time >= timeMove)
            {
                GetComponent<Rigidbody>().velocity = (new Vector3(1, 0f, -1)).normalized * speed;
                isRight = false;
            }
            else if (!isRight && Time.time >= timeMove)
            {
                GetComponent<Rigidbody>().velocity = (new Vector3(-1, 0f, -1)).normalized * speed;
                isRight = true;
            }
                timeMove = Time.time + timeNewMove;
        }
    }
}
