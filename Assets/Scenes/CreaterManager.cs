using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreaterManager : MonoBehaviour
{
    public InputField question;
    public InputField optionText;
    public Button[] options;
    string[] buttontext;
    public Button Confirm;
    public GameObject Visualisation;
    public JsonHandler handler;
    int dataComplete = 0;

    private void Start()
    {
        question.onValueChanged.AddListener(OnInputValueChanged);
        optionText.onValueChanged.AddListener(OnInputValueChanged);
        buttontext = new string[options.Length]; 
        for (int i = 0; i < options.Length; i++)
        {
            buttontext[i] = options[i].transform.GetChild(0).GetComponent<Text>().text;
        }
    }
    private void OnInputValueChanged(string newText)
    {
        dataComplete += 1;
        if(dataComplete == 2)
        {
            Confirm.interactable = true;
        }
    }

    private void Update()
    {
        //if(question.text != null)
        //{
        //    if (optionText.text != null)
        //    {
        //        if (dataComplete && solo == true)
        //        dataComplete = true;
        //        ButtonAvailible();
        //        solo = false; ;
        //    }
        //}
        
    }
    void updateVis()
    {
        Visualisation.transform.GetChild(0).GetComponent<Text>().text = question.text;
        options[0].GetComponent<Text>().text = buttontext[0]; //optionText.text; //split at , add foreach or for
    }

   public void confrimdata()
    {
        //append data to dataset
        handler.AppendNewData(question.text,0,buttontext);
    }

}
