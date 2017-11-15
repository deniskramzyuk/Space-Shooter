using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidRotation : MonoBehaviour
{
    public float speedRotation;
    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere*speedRotation;
    }
}
