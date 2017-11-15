using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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
           Vector3 movementMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(movementMouse.x, 0.0f, movementMouse.z);
        }
        else
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;
        }
        
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, zMin, zMax));
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * (-tilt));
        
    }

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float fireTime;
    void Update()
    {

        if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && Time.time >= fireTime)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            fireTime = Time.time + fireRate;
        }
    }
}
  