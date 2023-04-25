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
    public List<MyEnum> shape;
    public List<Color> color;
    public Image picture;

    public string statement;
    public personamanager manager;

    private void OnValidate()
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
        Debug.Log(statement + this.gameObject.name);
        if (statement == "correct")
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

