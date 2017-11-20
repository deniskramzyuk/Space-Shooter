using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByShot : MonoBehaviour
{
    public GameObject explosion;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("shot"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
       
    }
}