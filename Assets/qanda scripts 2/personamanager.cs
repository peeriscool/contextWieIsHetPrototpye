using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class personamanager : MonoBehaviour
{
    public List<PersonaData> data; //every card has its own data
    public GameObject[] options; //buttons with sprites
    // public int current; //index for 
    public PersonaData[] Opdracht;

    private void Start()
    {
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
