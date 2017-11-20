using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByShot : MonoBehaviour
{
    public GameObject explosion;
    public GameObject health;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("shot"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            if (Random.Range(1, 10) == 1)
            {
                Instantiate(health, transform.position, new Quaternion ());
            }
            Destroy(gameObject);
            Destroy(other.gameObject);

        }

    }
}