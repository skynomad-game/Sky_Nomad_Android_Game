using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    //Velocidad de Movimiento de la raqueta
    public float speed = 10;
    void FixedUpdate()
    {
        //Obtenemos la cantidad de movimiento en dirección horizontal
        float h = Input.GetAxisRaw("Horizontal");

        //Accedemos al Rigidbody2D de la raqueta
        //Voy siempre a la derecha X la dirección que el usuario haya introducido (1 derecha, 0 quieto, -1 izquierda) X la velocidad 
        GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed;
    }
}
