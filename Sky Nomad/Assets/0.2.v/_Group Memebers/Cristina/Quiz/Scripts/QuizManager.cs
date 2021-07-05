using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuizQuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;
    public Text ScoreTxt;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }

    public void Correct()
    {
        score += 1; //sumar si la respuesta es correcta
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }

    public void Wrong()
    {
        //cuando la respuesta no es correcta
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<QuizAnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];


            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<QuizAnswerScript>().isCorrect = true;
            }
        }
    }


    void generateQuestion()
    {
        if (QnA.Count > 0) { 
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionTxt.text = QnA[currentQuestion].Question;
        SetAnswers();
        }
        else
        {
            Debug.Log("No hay más preguntas");
            GameOver();
        }

    }

   


}
