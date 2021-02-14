﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thorns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Balloon")
        {
            Balloon Balloon = other.transform.GetComponent<Balloon>();
            Balloon.Die();
        }
    }
    
    

}
