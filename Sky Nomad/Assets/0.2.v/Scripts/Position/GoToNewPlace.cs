using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoToNewPlace : MonoBehaviour
{
    //Nombre de la escena a la que voy a teletransportar al jugador
    public string newPlaceName;
    public string uuid;
    public bool goInside;
    public bool goOutside;
    public Vector2 facingDirection;

    public GameObject loadingScreen;
    public TextMeshProUGUI loadingText;
    public GameObject loadingIcon;

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
            //SceneManager.LoadScene(newPlaceName);
            StartCoroutine(GoToNewScene());
        }
    }


    public IEnumerator GoToNewScene()
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(newPlaceName);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            
            {
                loadingText.text = "Nueva escena cargada \n Pulsa para continuar";
                loadingIcon.SetActive(false);

                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;

                    Time.timeScale = 1f;
                }
            }

            yield return null;
        }
    }


}
