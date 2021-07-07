using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;

   public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Respuesta Correcta");
            quizManager.Correct();
        }
        else
        {
            Debug.Log("Respuesta Erronea");
            quizManager.Wrong();
        }
    }
}
