using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public bool useMouse;
    public float speed;
    public float tilt;
    public Boundary boundary;

    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement;
        if (useMouse)
        {
           Vector3 movementMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(movementMouse.x, 0.0f, movementMouse.z);
        }
        else
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;
        }
        
        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * (-tilt));
        
    }

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float fireTime;
    public bool multishot = false;

   
    void Update()
    {
        if (multishot)
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && Time.time >= fireTime)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                Instantiate(shot, shotSpawn.position, Quaternion.Euler(shotSpawn.rotation.x, 45, shotSpawn.rotation.z));
                Instantiate(shot, shotSpawn.position, Quaternion.Euler(shotSpawn.rotation.x, -45, shotSpawn.rotation.z));
                fireTime = Time.time + fireRate;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && Time.time >= fireTime)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                fireTime = Time.time + fireRate;
                GetComponent<AudioSource>().Play();
            }
        }
    }



    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }
} 