using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{

    private PlayerController player;
    private CameraFollow theCamera;
    public Vector2 facingDirection = Vector2.zero;

    //nombre del identificador del Start Point
    public string uuid;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraFollow>();

        //en el caso de que la nextUuid sea nula o no sea igual a la Uuid de este StartPoint se saldrá i no se jecutará el código posterior
        /*
        if (player.nextUuid == null|| !player.nextUuid.Equals(uuid))
        {
            return;
        }
        */
        //Si llega a este punto
        //transforma la posición de jugados a la posición de este StartPoint
        //player.transform.position = this.transform.position;
        //la posición de la camara es transformada a la posición X e Y a la misma posición del StartPoint
        //theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);

        //player.lastMovement = facingDirection;
        
    }
}
