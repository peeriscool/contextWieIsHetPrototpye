using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
[RequireComponent(typeof(Button))]
public class PersonaData : MonoBehaviour
{
    [Range(1, 10)]
    public int procentScore; //percentage van overeenkomst bij doelgroep

    public List<MyEnum> shape; //defines which shapes the card has
 
    public List<Color> color; //color define
    
    public Image picture; //visual of persona

    public string Note; //information about this card
    
    public personamanager manager; //refrence back to the manager (Not ideal)

    private void OnValidate() //refresh Card in inspector with card on button
    {
        GetImage();
    }

    void GetImage()
    {
        picture = this.GetComponent<Button>().image;
    }

    public enum MyEnum
    {
        cubes,
        circle,
        driehoek,
        ruit,
        star,
        corner,
        zeshoek
    };

    public void ConfirmChoice()
    {
        Debug.Log(Note + this.gameObject.name);
        //send data of card to blackboard of sorts
        PlayerChoices.instance.AddAnswer(this);
        manager.Confirm();
        //if (Note == "correct")
        //{
        //    Debug.Log(Note);
        //    
        //}
        //else
        //{
        //    Debug.Log("Wrong");
        //    manager.Confirm();
        //}
    }
}

