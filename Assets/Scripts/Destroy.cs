using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public GameObject gameController;
    public GameObject explosion;


    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("asteroid"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gameController.GetComponent<GameOver>().Death();
        }
    }
}
