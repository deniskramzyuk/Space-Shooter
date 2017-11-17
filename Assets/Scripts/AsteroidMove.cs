using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{

    public float speed;

    void Start()
    {
        Vector3 move = new Vector3();
        move = transform.forward * speed;
        GetComponent<Rigidbody>().velocity = move;
        GetComponent<DestroyByContact>().speed = move;
    }
}