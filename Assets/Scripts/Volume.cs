using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public GameObject sliderVolume;

    public void volumeSlider()
    {
        AudioListener.volume = 1f - sliderVolume.gameObject.GetComponent<Slider>().value;
    }
    
}
