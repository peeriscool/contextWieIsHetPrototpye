using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MiniGameManager : MonoBehaviour
{
    //------------------------------------variables------------------------------------------------------------
    public int objectcount;
    public GameObject Finger;
    public GameObject[] shapes;
    public Button[] buttons;
    Shapemanager manager;
    //---------------------------------------functions---------------------------------------------------------
    void Start()
    {
        manager = new Shapemanager(shapes);
        manager.generateObjects(objectcount);
        originalColors = buttons[0].colors;
    }

    void Update()
    {
        //-------------------------input Mouse--------------------------------------------------------------------
        Finger.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - Vector3.back*5);
        if(Input.GetMouseButtonDown(0))
        {
            Finger.GetComponent<SpriteRenderer>().color = Color.green;
        }
        if (Input.GetMouseButtonDown(1))
        {
            Finger.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
           Finger.GetComponent<SpriteRenderer>().color = Color.white;
        }
        //-------------------------input down--------------------------------------------------------------------
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Button but = buttons[0];
            ChangeHighlightedColor(but);

            but.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Button but = buttons[1];
            ChangeHighlightedColor(but);
            but.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Button but = buttons[2];
            ChangeHighlightedColor(but);
            but.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Button but = buttons[3];
            ChangeHighlightedColor(but);
            but.onClick.Invoke();
        }
        //-------------------------input up--------------------------------------------------------------------
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Button but = buttons[0];
            ResetColors(but);

            but.onClick.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Button but = buttons[1];
           ResetColors(but);
            but.onClick.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Button but = buttons[2];
           ResetColors(but);
            but.onClick.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Button but = buttons[3];
           ResetColors(but);
            but.onClick.Invoke();
        }
    }
    //---------------------------------------Public functions---------------------------------------------------------
    public void triggerbutton(int input)
    {
        Debug.Log("Pressed input: " + input);
    }
    //--------------------------------------button to keyboard----------------------------------------------------------
    public Color highlightedColor;
    private ColorBlock originalColors;
    public void ChangeHighlightedColor(Button _but)
    {
        ColorBlock colorBlock = _but.colors;//buttons[i].colors;
        colorBlock.normalColor = Color.green;
        _but.colors = colorBlock;
    }
    public void ResetColors(Button _but)
    {
        _but.colors = originalColors;
    }
    //------------------------------------------------------------------------------------------------
}
public class Shapemanager
{
    GameObject[] shapes;
    public Shapemanager(GameObject[] _shapes)
    {
        shapes = _shapes;
    }  

    public void generateObjects(int length)
    {
        for (int i = 0; i < length; i++)
        {
            string name = i.ToString();
            GameObject ding = GameObject.Instantiate(shapes[Random.Range(0,shapes.Length)],new Vector3(Random.Range(0,10), Random.Range(0, 10), Random.Range(0, 10)),Quaternion.identity);
            ding.name = name;
        }
    }
}