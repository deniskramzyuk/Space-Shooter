using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool useMouse;
    public float speed;
    public float tilt;
    public Boundary boundary;
    float timeHealth = 3;
    public GameObject shot;
    public Transform shotSpawn;
    [HideInInspector]
    public float fireRate = 0.5f;
    private float fireTime;
    public bool multishot = false;
    public GameObject GameController;
    [HideInInspector]
    public float timeShield = 5f;
    private bool isShield = false;
    [System.Serializable]
    public class Boundary
    {
        public float xMin, xMax, zMin, zMax;
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (useMouse)
        {
            Vector3 movementMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(movementMouse.x, 0.0f, movementMouse.z);
        }
        else
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            GetComponent<Rigidbody>().velocity = movement * speed;
        }

        GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * (-tilt));

    }


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

        if (isShield)
        {
            invokeDisablseShield();
        }
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("health"))
        {
            Destroy(other.gameObject);
            GetComponent<Collider>().isTrigger = true;
            Invoke("disableTrigger", timeHealth);
            GetComponent<DestroyPlayer>().addLife();
        }
        if (other.gameObject.tag.Equals("score"))
        {
            Destroy(other.gameObject);
            GameController.GetComponent<Score>().AddScore(GameController.GetComponent<Bonus>().scoreValue);

        }
        if (other.gameObject.tag.Equals("lvlup"))
        {
            Destroy(other.gameObject);
            if (fireRate > 0.101f)
                fireRate -= 0.1f;
        }
        if (other.gameObject.tag.Equals("multishot"))
        {
            Destroy(other.gameObject);
            multishot = true;
        }
        if (other.gameObject.tag.Equals("shield"))
        {
            Destroy(other.gameObject);
            enableShield();
        }
    }


    void enableCollider()
    {
        gameObject.GetComponent<Collider>().enabled = true;
    }


    public void invokeEnableCollider(float time)
    {
        Invoke("enableCollider", time);
    }



    void disableTrigger()
    {
        gameObject.GetComponent<Collider>().isTrigger = false;
    }

    void enableShield()
    {
        timeShield = 5f;
        transform.GetChild(2).gameObject.SetActive(true);
        isShield = true;
    }

    void disableShield()
    {
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void invokeDisablseShield()
    {
        timeShield -= Time.deltaTime;
        if (timeShield <= 0)
        {
            disableShield();
            isShield = false;
        }
    }
}
