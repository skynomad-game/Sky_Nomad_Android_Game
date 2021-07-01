using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimCharacterController : MonoBehaviour
{

    public Animator _animator;

    public TextMeshProUGUI uiCharacterName;

    public string npcName /*, npcDialogue*/;
    public string[] npcDialogueLines;
    private Sprite npcSprite;

    private AnimManager dialogueManager;

    public bool isTalking;

    public Sprite showedSprite;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        //npcSprite = GetComponent<SpriteRenderer>().sprite;
        npcSprite = showedSprite;
        dialogueManager = FindObjectOfType<AnimManager>();
        Debug.Log("Soy " +this.gameObject.name);
    }

    public void walkRight()
    {
        _animator.SetBool("Walking", true);
        _animator.SetFloat("Horizontal", 1);
        _animator.SetFloat("Vertical", 0);
    }

    public void walkLeft()
    {
        _animator.SetBool("Walking", true);
        _animator.SetFloat("Horizontal", -1);
        _animator.SetFloat("Vertical", 0);
    }

    public void walkUp()
    {
        _animator.SetBool("Walking", true);
        _animator.SetFloat("Horizontal", 0);
        _animator.SetFloat("Vertical", 1);
    }

    public void walkDown()
    {
        _animator.SetBool("Walking", true);
        _animator.SetFloat("Horizontal", 0);
        _animator.SetFloat("Vertical", -1);
    }

  
    public void Talk()
    {
        Debug.Log("Voy a hablar");
        uiCharacterName.text = npcName;
        string[] finalDialogue = new string[npcDialogueLines.Length];
        //para cada linea de dialogo, recorro todas las lineas de dialogo
        int i = 0;

        foreach (string line in npcDialogueLines)
        {
            finalDialogue[i++] = line;
        }

        dialogueManager.ShowDialogue(finalDialogue, npcSprite);

        isTalking = true;
    }

    public void StopWalking(Vector2 facingDirection)
    {
        Debug.Log("ME paro");
        _animator.SetBool("Walking", false);

        _animator.SetFloat("Last_H", facingDirection.x);
        _animator.SetFloat("Last_V", facingDirection.y);


    }

}
