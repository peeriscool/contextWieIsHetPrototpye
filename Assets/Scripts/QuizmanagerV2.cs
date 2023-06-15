using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// Todo: add amount of questions on screen
/// make it so u can go back to start
/// 
/// </summary>
public class QuizmanagerV2 : MonoBehaviour
{
    public JsonHandler handler;
    //public List<QAndAScript> QnaA;
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
       string[] data =  handler.ReadanswersRequest(currentQuestion);
        for (int i = 0; i < options.Length; i++)
        {
            //if(options.Length >= data.Length)
            //{
            //    options[i].transform.GetChild(0).GetComponent<Text>().text = "Not enough answers";
            //}
            //else
            //{
                options[i].transform.GetChild(0).GetComponent<Text>().text = data[i].ToString(); //QnaA[currentQuestion].Answers[i];

          //  }
            // QnaA[currentQuestion].AnswerInt = (i);
        }
        currentQuestion += 1;
    }
    public void AnswerGiven(string _answer)
    {
        Debug.Log(_answer);
        GenerateQuestion();
    }
    public void GenerateQuestion()
    {
            questionText.text = handler.ReadquestionRequest();  //QnaA[currentQuestion].question;
            setanswer();
    }
}
