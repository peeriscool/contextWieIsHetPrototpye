using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quizmanager : MonoBehaviour
{
    public List<QAndAScript> QnaA;
    public GameObject[] options;
    public int currentQuestion;

    public Text questionText;

    public void Start()
    {
        currentQuestion = 0;

        GenerateQuestion();
    }

    void setanswer ()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnaA[currentQuestion].Answers[i];

            //if (QnaA[currentQuestion].AnswerInt == ((int)AnswerScript.statement.agree))
            //{ 

            //}
            //ToDo Save answer

            QnaA[currentQuestion].AnswerInt = (i);
        }
    }
    public void AnswerGiven(string _answer)
    {
        Debug.Log(_answer);
        GenerateQuestion();
    }
    public void GenerateQuestion()
    {
        if (currentQuestion >= QnaA.Count)
        {
            Debug.Log(currentQuestion.ToString() + " current / amount " + QnaA.Count); ;
        }
        else
        { 
            questionText.text = QnaA[currentQuestion].question;
            setanswer();
            QnaA.RemoveAt(currentQuestion);
        }
    }
}
