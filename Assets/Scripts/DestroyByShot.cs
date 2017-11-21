using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByShot : MonoBehaviour
{
    public GameObject explosion;
    public GameObject health;
    public int scoreByDestr;

    [HideInInspector]
    public GameObject GameController;

    [HideInInspector]
    public Vector3 speed;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("shot"))
        {
            GameController.GetComponent<Score>().AddScore(scoreByDestr);
            Instantiate(explosion, transform.position, transform.rotation);
            int rand = Random.Range(1, 100);
            if (rand >= 1 & rand <= 5)
            {
                Instantiate(health, transform.position, new Quaternion());
            }
            Destroy(gameObject);
            Destroy(other.gameObject);

        }

    }


   
    public void OnCollisionEnter(Collision other)
    {

        GetComponent<Rigidbody>().velocity =speed;
    }



    public void setGameController(GameObject gameController)
    {
        GameController = gameController;
    }
}