using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public bool isCorrect = false;
    public Gamemanager quizmanager;
   public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("correct");
            quizmanager.correct();
        }
        else
        {
            Debug.Log("Wrong");
            quizmanager.correct();
        }
   }
}
