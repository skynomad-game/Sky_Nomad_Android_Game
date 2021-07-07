using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int lives = 1;

    //Si el bloque choca con algo, tiene que ser con lo único que se mueve por pantalla, es decir, la bola!!
    private void OnCollisionEnter2D(Collision2D collision)
    {
        lives--; //Restar uno
        if (lives <= 0) //cuando el numero de vidas es menor o igual a 0 invocar a Destroy
        {
            Destroy(this.gameObject);
        }
    }


}

