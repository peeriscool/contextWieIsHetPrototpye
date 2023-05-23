using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameManager Instance;
    [SerializeField]
    CanvasRaycaster raycaster;
    public float timer = 0;
 //   FSM<s>

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        Debug.Log("Welkom screen activated");
        DontDestroyOnLoad(Instance);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void Update()
    {
     if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(timer);
        }
    }

    public void StartScene(string Scene) //single load scenes
    {
      //  Debug.Log("Going to Scene: " + Scene);
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
    }
    public void NextScene() //single load scenes
    {
        //  Debug.Log("Going to Scene: " + Scene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);
    }
    public void AppendScene(string Scene) //single load scenes
    {
        //  Debug.Log("Going to Scene: " + Scene);
        SceneManager.LoadScene(Scene, LoadSceneMode.Additive);
    }
    /// <summary>
    /// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
    /// </summary>  
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) //zet het spel terug naar pasieve staat
    {
        if(scene.name == "Menu")
        {
            Debug.Log("Menu");
        }
        if(scene.name == "lvl0") //start een tijd is geld timer
        {
            Debug.Log("Lvl 0");
            //raycaster.assignCanvas(GameObject.Find("Canvas_SpeelVeld").GetComponent<Canvas>());
            //raycaster.assignCamera(Camera.main);
            AppendScene("UIscene");
        }
        if (scene.name == "lvl01")
        {
            AppendScene("UIscene");
            Debug.Log("lvl01");
        }
        if (scene.name == "lvl02")
        {
            AppendScene("UIscene");
            Debug.Log("lvl02");
        }
        if (scene.name == "lvl03")
        {
            AppendScene("UIscene");
            Debug.Log("lvl03");
        }
        if (scene.name == "lvl04")
        {
            AppendScene("UIscene");
            Debug.Log("lvl04");
        }
        if (scene.name == "lvl05")
        {
            AppendScene("UIscene");
            Debug.Log("lvl05");
        }
        //  Debug.Log("OnSceneLoaded: " + scene.name);
    }
}
