using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class personamanager : MonoBehaviour
{
    List<PersonaData> data; //every card has its own data
    public GameObject[] options; //buttons with sprites
    public PersonaData[] Opdracht; //the data which you are looking for
    void filldatalist()
    {
        data = new List<PersonaData>();
        for (int i = 0; i < options.Length; i++)
        {
            data.Add(options[i].GetComponent<PersonaData>());
        }
    }
    private void Start()
    {
        filldatalist();
        Generatequestion();

    }
    public void Confirm()
    {
        //not really correct
        if(data.Count > 1 )
        {
          //  data.RemoveAt(current);
        }
        Generatequestion();
    }
    void Generatequestion()
    {
       // current = 0;                                     
        SetAnswer();

    }
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++) //for each defined button
        {
            options[i].GetComponent<Image>().sprite = data[i].picture.sprite;//options[i].GetComponent<PersonaData>().picture.sprite;
                Debug.Log("Set answer");
            //data[i].shape[i].ToString()
        }
    }
    
}
