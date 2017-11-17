using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    [HideInInspector]
    public Vector3 speed;


    public void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().velocity = speed;
        if (other.gameObject.tag.Equals("Player"))
        {
            GetComponent<Rigidbody>().velocity = speed;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX & RigidbodyConstraints.FreezePositionY;
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
        }
    }
}