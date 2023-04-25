using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoices:MonoBehaviour 
{
    public static PlayerChoices instance;
    List<PersonaData> choices;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        choices = new List<PersonaData>();

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    public void AddAnswer(PersonaData data)
    {
        Debug.Log("Adding" + data.name + "to choices");
        choices.Add(data);
    }
   
}
