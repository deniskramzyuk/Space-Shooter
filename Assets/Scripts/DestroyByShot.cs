﻿using System.Collections;
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
            GameController.GetComponent<Bonus>().addBonus(gameObject);
            Destroy(gameObject);
            Destroy(other.gameObject);

        }

    }



    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
            GetComponent<Rigidbody>().velocity = speed;
        //if (other.gameObject.tag.Equals("shield"))
        //    Destroy(gameObject);
    }



    public void setGameController(GameObject gameController)
    {
        GameController = gameController;
    }
}