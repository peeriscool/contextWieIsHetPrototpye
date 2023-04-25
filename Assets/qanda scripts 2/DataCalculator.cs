using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCalculator : MonoBehaviour
{
   public string statement;
   public personamanager manager;
   public void ConfirmChoice()
    {
        Debug.Log(statement + this.gameObject.name);
        if(statement == "correct")
        {
            Debug.Log(statement);
            manager.Confirm();
        }
        else
        {
            Debug.Log("Wrong");
            manager.Confirm();
        }
    }
}
