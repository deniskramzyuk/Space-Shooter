using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isMouse;
    public float speed;
    public float xMin, xMax, zMin, zMax;
    public float tilt;


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement;
        if (isMouse)
        {
           Vector3 buf = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(buf.x, 0, buf.z);
        }
        else
        {
            movement = new Vector3(moveHorizontal, 0, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;
        }
        
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, zMin, zMax));
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * (-tilt));
        
    }
}
  