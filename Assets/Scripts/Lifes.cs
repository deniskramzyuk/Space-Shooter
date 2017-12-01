using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour {

    public GameObject player;

    void Start()
    {
        updLifesText();
    }


    public void updLifesText()
    {
        player.GetComponent<DestroyPlayer>().lifesText.text = "x " + player.GetComponent<DestroyPlayer>().startLifes.ToString();
    }
}
