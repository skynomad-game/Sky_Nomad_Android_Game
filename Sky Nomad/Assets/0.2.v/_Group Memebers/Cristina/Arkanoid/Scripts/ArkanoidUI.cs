using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArkanoidUI : MonoBehaviour
{
    public Image live1, live2, live3;
    public Text gameOverText, gameWinText, durationText, highScoreText;
    private bool hasTheGameEnded = false;

    private float gameTime = 0.0f; 
    BallArkanoid ball;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.enabled = false; //desactivar en la jerarquia el texto con el game over
        gameWinText.enabled = false; //desactivar en la jerarquia el texto con el ganar
        ball = GameObject.Find("Ball").GetComponent<BallArkanoid>(); //busca en la jerarquia un objeto llamado Ball y recoge su script de tipo BallArkanoid
        highScoreText.text = "Mejor: "+PlayerPrefs.GetFloat("hightscore", 9999).ToString("N2");
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTheGameEnded)
        {
            return; //si ha acabado el juego sale del método
        }
        gameTime += Time.deltaTime; //sumar poco a poco fragmentos de tiempo
        durationText.text = gameTime.ToString("N2"); //N2 para convertir a dos decimales

        if (ball.lives < 3)
        {
            live3.enabled = false; //desactivar la vida número 3
        }
        if (ball.lives < 2)
        {
            live2.enabled = false; //desactivar la vida número 2
        }
        if (ball.lives < 1)
        {
            live1.enabled = false; //desactivar la vida número 1
            gameOverText.enabled = true; //aparece el texto con el mensaje de Game Over
            Invoke("GoToMainMenuMiniGames", 2.0f); //invocar para llevarlo a la pantalla de inicio de los mini juegos después de 2 segundos
            hasTheGameEnded = true;
        }
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 0) {
            gameWinText.text = "Enhorabuena\nHas ganado en " + gameTime.ToString("N2"); //N2 para convertir a dos decimales
             gameWinText.enabled = true;
            Invoke("GoToMainMenuMiniGames", 2.0f);  //invocar para llevarlo a la pantalla de inicio de los mini juegos después de 2 segundos
            hasTheGameEnded = true;

            float highscore = PlayerPrefs.GetFloat("highscore", 9999); //tabla highscore
            if(gameTime < highscore)
            {
                PlayerPrefs.SetFloat("highscore", gameTime);
            }
        }

    }

    void GoToMainMenuMiniGames()
    {
        SceneManager.LoadScene("ArkanoidMainMenu");
    }
}
