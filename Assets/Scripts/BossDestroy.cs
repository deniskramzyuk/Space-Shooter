using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDestroy : MonoBehaviour
{

    public GameObject explosion;
    public int scoreByDestr;

    [HideInInspector]
    public GameObject GameController;

    [HideInInspector]
    public Vector3 speed;

    private int lifes = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("shot"))
        {
            lifes--;
            Destroy(other.gameObject);
            transform.GetChild(2).transform.GetChild(0).GetComponent<Slider>().value += 0.02f;
            if (lifes == 15) GetComponent<BossShot>().fireRate = 1;
            if (lifes == 0)
            {
                GameController.GetComponent<Score>().AddScore(scoreByDestr);
                Instantiate(explosion, transform.position, transform.rotation);
                GameController.GetComponent<Bonus>().addBonus(gameObject);
                if (GameController.GetComponent<SpawnWaves>().isEndless == false)
                {
                    GameController.GetComponent<WinText>().Win();
                }
                GameController.GetComponent<SpawnWaves>().isEndOfWave = false;
                GameController.GetComponent<SpawnWaves>().count = 0;
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }

    }



    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
            GetComponent<Rigidbody>().velocity = speed;
    }



    public void setGameController(GameObject gameController)
    {
        GameController = gameController;
    }
}
