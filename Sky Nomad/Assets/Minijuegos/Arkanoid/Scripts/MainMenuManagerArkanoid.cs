using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManagerArkanoid : MonoBehaviour
{
    public void LoadPong()
    {
     //   SceneManager.LoadScene("PongScene");
    }

    public void LoadArkanoid()
    {
        SceneManager.LoadScene("ArkanoidScene");
    }

}
