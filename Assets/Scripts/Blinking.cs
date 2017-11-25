using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{

    private float time = 5f;
    private float colorA;
    private bool isColor=true;

    private void Start()
    {
        colorA = GetComponent<MeshRenderer>().material.color.a;
    }

    void Update()
    {
        time = transform.parent.gameObject.GetComponent<PlayerController>().timeShield;
        if (time <= 2)
            blinkingShield();
    }

    void blinkingShield()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            int bun = ((int)(time / (1f / 6f))) % 2;
            if (bun == 1)
            {
                if (isColor)
                {
                    GetComponent<MeshRenderer>().material.color -= new Color(0, 0, 0, colorA);
                    isColor = false;
                }
            }
            else
            {
                if (!isColor)
                {
                    GetComponent<MeshRenderer>().material.color += new Color(0, 0, 0,colorA);
                    isColor = true;
                }

            }
        }
    }
}
