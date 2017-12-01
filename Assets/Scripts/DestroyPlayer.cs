using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyPlayer : MonoBehaviour
{

    public GameObject gameController;
    public GameObject explosion;
    public int startLifes = 3;
    private int lifes;
    public int maxLifes = 3;
    public Text lifesText;
    private float timer = 3f;
    private bool isReborn = false;

    private void Update()
    {
        if (isReborn)
            Reborn();
    }

    private void Start()
    {
        lifes = startLifes;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("asteroid") || other.gameObject.tag.Equals("enemy") || other.gameObject.tag.Equals("shot enemy") || other.gameObject.tag.Equals("boss"))
        {
            if (transform.GetChild(2).gameObject.activeSelf && (other.gameObject.tag.Equals("asteroid") || other.gameObject.tag.Equals("enemy") || other.gameObject.tag.Equals("shot enemy")))
            {
                if (other.gameObject.tag.Equals("shot enemy"))
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    GetComponent<PlayerController>().GameController.GetComponent<Score>().AddScore(other.gameObject.GetComponent<DestroyByShot>().scoreByDestr);
                    Instantiate(other.gameObject.GetComponent<DestroyByShot>().explosion, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject);
                }
            }
            else
            {
                removeLife();
                if (lifes != 0)
                {
                    if (other.gameObject.tag.Equals("shot enemy"))
                        Destroy(other.gameObject);
                    gameObject.GetComponent<Collider>().enabled = false;
                    Instantiate(explosion, transform.position, transform.rotation);
                    gameObject.GetComponent<Rigidbody>().position = new Vector3();
                    isReborn = true;
                    GetComponent<PlayerController>().fireRate = 0.5f;
                    GetComponent<PlayerController>().multishot = false;
                    GetComponent<PlayerController>().invokeEnableCollider(3f);
                }
                else
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                    gameObject.SetActive(false);
                    gameController.GetComponent<GameOver>().Death();
                }
            }
        }
    }

    public void removeLife()
    {
        lifes--;
        lifesText.text = "x " + lifes.ToString();
    }

    public void addLife()
    {
        if (lifes < maxLifes)
        {
            lifes++;
            lifesText.text = "x " + lifes.ToString();
        }
    }

    void Reborn()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int bun = ((int)(timer / (1f / 6f))) % 2;
            if (bun == 1)
            {
                if (GetComponent<MeshRenderer>().enabled)
                {
                    GetComponent<MeshRenderer>().enabled = false;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
            }
            else
            {
                if (!GetComponent<MeshRenderer>().enabled)
                {
                    GetComponent<MeshRenderer>().enabled = true;
                    transform.GetChild(0).gameObject.SetActive(true);
                }
            }
        }
        else
        {
            isReborn = false;
            timer = 3f;
            GetComponent<MeshRenderer>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }


    public void resetLifes()
    {
        lifes = startLifes;
    }
}