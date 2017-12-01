using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinText : MonoBehaviour {

    public GameObject winText;


    public void Win()
    {
        winText.SetActive(true);
    }
}
