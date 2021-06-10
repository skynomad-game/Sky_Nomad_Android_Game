using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNewPlace : MonoBehaviour
{
    //Nombre de la escena a la que voy a teletransportar al jugador
    public string newPlaceName;
    public string uuid;
    public bool goInside;
    public bool goOutside;
    public Vector2 facingDirection;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.tag == "Player")
        {

            if (goInside)
            {
                Debug.Log("Va hacia dentro");

            }
            else if (goOutside)
            {
                Debug.Log("Va hacia fuera");

            }

            FindObjectOfType<PlayerController>().nextUuid = uuid;
            Debug.Log(FindObjectOfType<PlayerController>().nextUuid);
            PlayerPrefs.SetString("playerNextUuid", uuid);
            PlayerPrefs.SetString("comeFromquest", "no");
            SceneManager.LoadScene(newPlaceName);
        }
    }

}
