﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
            collision.transform.GetComponent<PLayerChekPoint>().PlayerDamaged();
        }
    }
}
