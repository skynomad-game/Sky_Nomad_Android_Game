using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    public GameObject[] levelPieces;

    public GameObject currentPiece, nextPiece;


    public void Start()
    {
        nextPiece = Instantiate(levelPieces[0], this.transform.position, Quaternion.identity);
        SpawnNextPiece();
    }
    public void SpawnNextPiece()
    {
        currentPiece = nextPiece;
        currentPiece.GetComponent<Piece>().enabled = true;

        Debug.Log("Tengo estos hijos: " + this.gameObject.GetComponentsInChildren<SpriteRenderer>().Length);
        foreach(SpriteRenderer child in this.gameObject.GetComponentsInChildren<SpriteRenderer>()) {
            Debug.Log("Componentes del hijo");
            Color currentColor = child.color;
            currentColor.a = 1.0f;
            child.color = currentColor;
        }
      
        StartCoroutine("PrepareNextPiece"); 
    }

    IEnumerator PrepareNextPiece() {
        yield return new WaitForSecondsRealtime(3.0f);

        //aleatoriamente decido qué pieza del array debe spawnearse
        int i = Random.Range(0, levelPieces.Length);

        //instanciar donde el padre (posicion del padre) y con la misma rotación que tenga el padre
    nextPiece =  Instantiate(levelPieces[i], this.transform.position, Quaternion.identity);
        nextPiece.GetComponent<Piece>().enabled = false;
       
        foreach(SpriteRenderer child in GetComponentsInChildren<SpriteRenderer>()) {

        Color currentColor = child.color;
        currentColor.a = 0.3f;
            child.color = currentColor;
        }
    }
}
