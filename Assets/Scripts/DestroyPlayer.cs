using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyPlayer : MonoBehaviour
{

    public GameObject gameController;
    public GameObject explosion;
    public int lifes = 3;
    public Text lifesText;
    private float timer=3f;
    private bool isReborn=false;

    private void Update()
    {
        if (isReborn)
            Reborn();
    }



    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("asteroid"))
        {
            if (transform.GetChild(2).gameObject.activeSelf)
            {
                GetComponent<PlayerController>().GameController.GetComponent<Score>().AddScore(other.gameObject.GetComponent<DestroyByShot>().scoreByDestr);
                Instantiate(other.gameObject.GetComponent<DestroyByShot>().explosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
            }
            else
            {
                removeLife();
                if (lifes != 0)
                {
                    gameObject.GetComponent<Collider>().enabled = false;
                    Instantiate(explosion, transform.position, transform.rotation);
                    gameObject.GetComponent<Rigidbody>().position = new Vector3();
                    //StartCoroutine(Reborn());
                    isReborn = true;
                    GetComponent<PlayerController>().fireRate = 0.5f;
                    GetComponent<PlayerController>().multishot = false;
                    GetComponent<PlayerController>().invokeEnableCollider(3f);
                }
                else
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                    Destroy(gameObject);
                    gameController.GetComponent<GameOver>().Death();
                }
            }
        }
    }
    /*IEnumerator Reborn()
    {
        GetComponent<Animator>().SetBool("isReborn", true);
        yield return new WaitForSeconds(3f);
        GetComponent<Animator>().SetBool("isReborn", false);
    }*/


    public void removeLife()
    {
        lifes--;
        lifesText.text = "x " + lifes.ToString();
    }

    public void addLife()
    {
        if (lifes < 3)
        {
            lifes++;
            lifesText.text = "x " + lifes.ToString();
        }
    }

    void Reborn()
    {
        if (timer>0)
        {
            timer -= Time.deltaTime;
            int bun = ((int)(timer / (1f / 6f)))%2;
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
}