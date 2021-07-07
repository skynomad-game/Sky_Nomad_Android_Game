using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject [] cards;

    private Card primeraCarta;
    private Card segundaCarta;

    private void Start()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 0; i < cardFace.Length; i++)
            {
                bool test = false;
                int choice = 0;

                while (!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized);
                }
                cards[choice].GetComponent<Card>().cardFace = cardFace[i];
                cards[choice].GetComponent<Card>().initialized = true;
            }
        
        }
    }


    public void EvaluarCartas(Card carta)
    {
        if (primeraCarta == null)
        {
            carta.GetComponent<Image>().sprite = carta.cardFace;
            primeraCarta = carta;
        }
        else if (segundaCarta == null)
        {
            carta.GetComponent<Image>().sprite = carta.cardFace;
            segundaCarta = carta;
            if (primeraCarta.GetComponent<Image>().sprite == segundaCarta.GetComponent<Image>().sprite)
            {
                Debug.Log("Exito");
                primeraCarta = null;
                segundaCarta = null;
            }
            else
            {
                StartCoroutine(DejarComoAlPrincipio());
            }
        }

    }

    IEnumerator DejarComoAlPrincipio()
    {
        yield return new WaitForSeconds(1f);
        primeraCarta.GetComponent<Image>().sprite = cardBack;
        segundaCarta.GetComponent<Image>().sprite = cardBack;
        primeraCarta = null;
        segundaCarta = null;
    }


}
