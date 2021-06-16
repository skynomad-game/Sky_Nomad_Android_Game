using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public string selectScene;

    public string firstLevel;

    public GameObject optionsScreen;

    public GameObject loadingScreen, loadingIcon;
    public TextMeshProUGUI loadingText;

    public TextMeshProUGUI textButtonStart;

    private void Start()
    {

        if (PlayerPrefs.GetString("introMade", "no") == "yes")
        {
            textButtonStart.text = "Continuar";
        }
    }


    public void StartGame()
    {
        //SceneManager.LoadScene(firstLevel);
        StartCoroutine(LoadStart());
    }

public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

public void QuitGame()
    {
        Application.Quit();
    }

    //Coroutine for loading screen
    public IEnumerator LoadStart()
    {
        loadingScreen.SetActive(true);

        string nextScene = selectScene;   

        if (PlayerPrefs.GetString("introMade", "no") == "yes")
        {
            nextScene = firstLevel; 
        }
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);


        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                loadingText.text = "Pulsa para continuar";
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
