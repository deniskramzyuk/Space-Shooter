﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteShots : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}