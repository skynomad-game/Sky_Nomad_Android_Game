 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZoneArkanoid : MonoBehaviour
{
    /*public GameObject ballStartPosition;*/

    // Cuando detecte la bola en su interior automáticamente tien que reinicar la bola
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            /*collision.gameObject.transform.position = ballStartPosition.transform.position;*/
            collision.gameObject.GetComponent<BallArkanoid>().ResetBall();
            GetComponent<AudioSource>().Play(); //sonido componente audiosource de killzone

        }
    }


}
