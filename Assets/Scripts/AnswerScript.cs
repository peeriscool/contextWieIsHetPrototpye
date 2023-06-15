using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public enum statement { agree, disagree, no_opinion, Depends };
    statement Current;
    statement LastStatement;
    public Quizmanager quizmanager;

    public void Awake()
    {
        Current = 0;
        LastStatement = (statement)5;
    }
    public void Answer(int a)
    {
    //    LastStatement = Current;
        Current = (statement)a;
        respond();
    }

    // Update is called once per frame
    void respond()
    {
        if (Current != LastStatement)
        {
            switch (Current)
            {
                case statement.agree:

                    quizmanager.AnswerGiven(Current.ToString());
                    break;
                case statement.disagree:

                    quizmanager.AnswerGiven(Current.ToString());
                    break;
                case statement.no_opinion:

                    quizmanager.AnswerGiven(Current.ToString());
                    break;
                case statement.Depends:
                    quizmanager.AnswerGiven(Current.ToString());
                    break;
                default:
                    quizmanager.AnswerGiven("no answer");
                    break;
            }
        }
    }
}

