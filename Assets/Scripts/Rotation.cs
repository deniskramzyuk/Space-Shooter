using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speedRotation;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere*speedRotation;
    }
}
