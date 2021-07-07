using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public bool initialized = false;

    public Image cardBack;
    public Sprite cardFace;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        cardBack = GetComponent<Image>();
        cardBack.sprite = gameManager.cardBack;
        GetComponent<Button>().onClick.AddListener(flipCard);
    }

    public void flipCard()
    {
        //GetComponent<Image>().sprite = cardFace;
        gameManager.EvaluarCartas(this);
    }
}
