using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotsMove : MonoBehaviour {

    public float speed;

    void Start()
    { 
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}

