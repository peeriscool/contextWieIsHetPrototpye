using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class personamanager : MonoBehaviour
{
    public List<PersonaData> data; //every card has its own data
    public GameObject[] options;
    public int current;

    public PersonaData[] Opdracht;

    private void Start()
    {
        Generatequestion();
    }
    public void Confirm()
    {
        data.RemoveAt(current);
        Generatequestion();
    }
    void Generatequestion()
    {
        current = Random.Range(0, data.Count); //choice random question //future make list or dict
                                               // QandAtext.text = data[current].question;
        SetAnswer();

    }
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++) //for each defined button
        {
          //  Debug.Log(options[i].GetComponent<Image>().sprite);
         //   Debug.Log(data[i].picture.sprite);
            options[i].GetComponent<Image>().sprite = data[i].picture.sprite;//options[i].GetComponent<PersonaData>().vorm.sprite;
            if (data[current].procentScore == i+1) //1 to 4
            {
                Debug.Log("procentscore");
                options[i].GetComponent<DataCalculator>().statement = "leg uit";
            }
        }
    }
    
}
