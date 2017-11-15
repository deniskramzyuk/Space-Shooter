using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByShot : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("shot"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}