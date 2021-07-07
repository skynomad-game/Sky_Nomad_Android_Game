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

    public GameObject continueButton;

    private void Start()
    {
        if (!PlayerPrefs.GetString("introMade", "no").Equals("no"))
        {
            continueButton.GetComponent<Button>().enabled = true;
            continueButton.GetComponent<Image>().color = Color.white;
        }
    }

    public void StartGame()
    {
        //SceneManager.LoadScene(firstLevel);
        StartCoroutine(LoadStart());
    }

public void OpenOptions() {
        optionsScreen.SetActive(true);
    }

public void CloseOptions(){
        optionsScreen.SetActive(false);
    }

public void QuitGame() {
        Application.Quit();
    }

    public void RestartPlayerPrefs()
    {
        PlayerPrefs.SetString("introMade", "no");
        PlayerPrefs.SetInt("personajeEscogido", 0);
        PlayerPrefs.SetString("comeFromquest", "no");
        PlayerPrefs.SetString("questFraseCompleted", "no");
        PlayerPrefs.SetString("questPuzzleCompleted", "no");
        PlayerPrefs.SetString("questPlatformCompleted", "no");

        StartGame();


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
                loadingIcon.SetActive(false);
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
