using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
  //  public enum statement { agree, disagree, no_opinion, Depends };
    string Current = "";
    public QuizmanagerV2 quizmanager;

   
    public void Answer(int a)
    {
        Current =  this.transform.GetChild(0).GetComponent<Text>().text.ToString();
        Debug.Log( Current + " submited option");
        respond();
    }

    // Update is called once per frame
    void respond()
    {
            quizmanager.AnswerGiven(Current.ToString());
    }
}

