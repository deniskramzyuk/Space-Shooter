using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetButtonMy : MonoBehaviour
{

    public GameObject player;
    public GameObject boundary;
    public GameObject texts;
    public GameObject mainMenu;
    public AudioClip buttonClick;
    public AudioClip buttonClick2;
    public GameObject settings;
    public GameObject selectLevel;
    private bool musicOn = true;


    public void buttonSound()
    {
        gameObject.transform.GetChild(0).gameObject.GetComponent<AudioSource>().PlayOneShot(buttonClick);
    }

    public void buttonSound2()
    {
        gameObject.transform.GetChild(1).gameObject.GetComponent<AudioSource>().PlayOneShot(buttonClick2);
    }

    public void pressButtonNewGame()
    {
        gameObject.GetComponent<SpawnWaves>().enabled = true;
        player.gameObject.SetActive(true);
        boundary.gameObject.SetActive(true);
        texts.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        GetComponent<AudioSource>().enabled = true;
    }

    public void pressButtonExit()
    {
        Application.Quit();
    }


    public void onOffMusic()
    {
        if (musicOn)
        {
            settings.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            settings.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            AudioListener.volume = 0f;
            musicOn = false;
        }
        else
        {
            settings.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(false);
            settings.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            AudioListener.volume = 1f;
            musicOn = true;
        }
    }


    public void pressButtonSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void pressButtonBack()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
        selectLevel.SetActive(false);
    }

    public void pressButtonSelectLevel()
    {
        mainMenu.SetActive(false);
        selectLevel.SetActive(true);
    }
}
