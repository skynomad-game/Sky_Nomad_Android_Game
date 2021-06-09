using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    public float speed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        //Le damos la velocidad a la bola 
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    //Esta función se llama automáticamente cuando hay una colisión
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Comprobamos que el objeto con el que he colisionado es la pala (raqueta)
    if(collision.gameObject.name == "Paddle")
        {
            //Calculo la X con el hitFactor
            float x = hitFactor(this.transform.position, collision.transform.position, collision.collider.bounds.size.x); //x porque solo queremos la anchura
            Vector2 direction = new Vector2(x, 1).normalized; //normaliza el vector para que siempre tenga longitud 1

            GetComponent<Rigidbody2D>().velocity = direction * speed;//ahora tiene módulo speed
        }    
    }
    /*
     -0.5       -0.25        0       0.25      0.5
    ================================================= <- esto es la pala
     
     */
   
    
    float hitFactor(Vector2 ball, Vector2 paddle, float paddleWidth)
    {
        return (ball.x - paddle.x) / paddleWidth;
    }
}
