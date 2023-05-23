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

    /// <param time="time">seconden tot actie</param>
    IEnumerator TijdCoroutine(int time)
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(time);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        AppendScene("LoopScreen");
    }
 
    public void StartScene(string Scene) //single load scenes
    {
      //  Debug.Log("Going to Scene: " + Scene);
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
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
            Debug.Log("Lvl 0 assigning canvas and camera");
            raycaster.assignCanvas(GameObject.Find("Canvas_SpeelVeld").GetComponent<Canvas>());
            raycaster.assignCamera(Camera.main);
            AppendScene("UIscene");
        }
        Debug.Log("OnSceneLoaded: " + scene.name);
    }
}
