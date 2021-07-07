using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimCharacters : MonoBehaviour
{
    public GameObject firstCharacter;

    public GameObject parentPanel;

    public AudioManager audioManager;

    public void DisablePanelText()
    {
        firstCharacter.SetActive(true);
        parentPanel.SetActive(false);
        audioManager.PlayNewTrack(1);

    }
 }