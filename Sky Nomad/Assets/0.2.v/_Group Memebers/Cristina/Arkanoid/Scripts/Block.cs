using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Si el bloque choca con algo, tiene que ser con lo �nico que se mueve por pantalla, es decir, la bola!!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }


}

