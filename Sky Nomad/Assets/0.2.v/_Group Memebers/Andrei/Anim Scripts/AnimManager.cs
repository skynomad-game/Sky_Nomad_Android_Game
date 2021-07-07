using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;
using UnityEngine.SceneManagement;

public class AnimManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public Image avatarImage;
    public bool dialogueActive;
    public AudioManager audioManager;

    public GameObject[] nextAnimNPC;

    public string[] dialogueLines;
    public int currentDialogueLine;

    private GameObject continueButton;

    public string nextScene;

    public AnimPlayerMngr playerManager;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogueActive = false;
        dialogueBox.SetActive(false);
        continueButton = GameObject.Find("Continue Button");
        continueButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (CrossPlatformInputManager.GetButtonDown("Continue"))
        {
            Debug.Log("Se ha detectado la pulsación");

            currentDialogueLine++;
            /*
            dialogueActive = false;
            avatarImage.enabled = false;
            dialogueBox.SetActive(false);
            */
            //si la linea actual es mayor o igual que las lineas de dialogo
            if (currentDialogueLine >= dialogueLines.Length)
            {
                currentDialogueLine = 0;
                dialogueActive = false;
                avatarImage.enabled = false;
                dialogueBox.SetActive(false);
                continueButton.SetActive(false);
                if (i < nextAnimNPC.Length)
                {
                    nextAnimNPC[i].SetActive(true);
                    i++;
                }
               
                else if (playerManager.goToNextScene == true && dialogueActive == false)
                {
                    PlayerPrefs.SetString("introMade", "yes");
                    SceneManager.LoadScene(nextScene);
                }
                Debug.Log(i);

            }
            else
            {
                dialogueText.text = dialogueLines[currentDialogueLine];
            }

          
        }

      
    }

    public void ShowDialogue(string[] lines)
    {
        currentDialogueLine = 0;
        dialogueLines = lines;
        dialogueActive = true;
        dialogueBox.SetActive(true);
        //dialogueText.text = text;
        dialogueText.text = dialogueLines[currentDialogueLine];
        continueButton.SetActive(true);
    }

    public void ShowDialogue(string[] lines, Sprite sprite)
    {
        ShowDialogue(lines);
        avatarImage.enabled = true;
        avatarImage.sprite = sprite;
    }
}

