using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Balloon")
        {
            Balloon balloon = other.gameObject.GetComponent<Balloon>();
            balloon.Die();
        }
    }
}
