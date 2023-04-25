using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gamemanager : MonoBehaviour
{
    public List<QandA> QnA;
    public GameObject[] options;
    public int current;

    public Text QandAtext;

    private void Start()
    {
        Generatequestion();
    }
    public void correct()
    {
        QnA.RemoveAt(current);
        Generatequestion();
    }
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++) //for each defined button
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[current].answers[i];
            if(QnA[current].correct == i+1) //1 to 4
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }
    void Generatequestion()
    {
        current = Random.Range(0, QnA.Count); //choice random question //future make list or dict
        QandAtext.text = QnA[current].question;
        SetAnswer();

    }
}
