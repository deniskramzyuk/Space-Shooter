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
    private bool difficultMode = false;
    public GameObject backFromGame;

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
        GetComponent<SpawnWaves>().enabled = true;
        player.gameObject.SetActive(true);
        texts.gameObject.SetActive(true);
        selectLevel.gameObject.SetActive(false);
        GetComponent<AudioSource>().enabled = true;
        mainMenu.SetActive(false);
        backFromGame.SetActive(true);
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

    public void onOffDifficultMode()
    {
        if (!difficultMode)
        {
            settings.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            settings.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            difficultMode = true;
            player.GetComponent<DestroyPlayer>().startLifes = 1;
            player.GetComponent<DestroyPlayer>().maxLifes = 1;
            GetComponent<Lifes>().updLifesText();
        }
        else
        {
            settings.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            settings.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
            difficultMode = false;
            player.GetComponent<DestroyPlayer>().startLifes = 3;
            player.GetComponent<DestroyPlayer>().maxLifes = 3;
            GetComponent<Lifes>().updLifesText();
        }
    }

    public void LevelOne()
    {
        GetComponent<SpawnWaves>().isEndless = false;
        GetComponent<SpawnWaves>().enabled = true;
        player.gameObject.SetActive(true);
        texts.gameObject.SetActive(true);
        selectLevel.gameObject.SetActive(false);
        GetComponent<AudioSource>().enabled = true;
        backFromGame.SetActive(true);
    }

    public void BackFromGame()
    {
        SceneManager.LoadScene(0);
    }

}
