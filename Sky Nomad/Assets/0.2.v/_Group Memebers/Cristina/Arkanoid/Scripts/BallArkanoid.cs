using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallArkanoid : MonoBehaviour
{
    private float speed;
    public float initialspeed = 5;
    public GameObject ballStartPosition;
    public int lives = 3;

    [SerializeField]
    [Range(1.0f, 2.0f)]
    public float difficultyFactor = 1.005f;

    // Start is called before the first frame update
    void Start()
    {
        speed = initialspeed;
        //Le damos la velocidad a la bola 
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        StartCoroutine(UpgrateDifficulty());
    }

    IEnumerator UpgrateDifficulty() //Coroutina para aumentar la dificultad que espera un segundo y subira la velocidad
    {
        while (true) { 
        yield return new WaitForSeconds(1.0f);
            // speed += 0.5f;
            speed *= difficultyFactor;
        }
    }

    //Esta función se llama automáticamente cuando hay una colisión
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
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

    public void ResetBall()
    {
        lives--; //matar o restar una vida de la pelota
        speed = initialspeed;
        transform.position = ballStartPosition.transform.position;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (lives > 0) {  //si las vidas son mayores que 0 reseteo la bola
        Invoke("RestartBallMovement", 2.0f);
        }
     
    }

    void RestartBallMovement()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

   
}
