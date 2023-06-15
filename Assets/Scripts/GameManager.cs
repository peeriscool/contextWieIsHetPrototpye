using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameManager Instance;
    [SerializeField]
    public JsonHandler handler;
    private void Awake()
    {
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
        if(handler.IfNonExsistent())
        {
            handler.CreateJson();
        }
        DontDestroyOnLoad(Instance);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    public void StartScene(string Scene) //single load scenes
    {
      //  Debug.Log("Going to Scene: " + Scene);
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
    }
    public void NextScene() //single load scenes
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single);
    }
    public void AppendScene(string Scene) //single load scenes
    {
        SceneManager.LoadScene(Scene, LoadSceneMode.Additive);
    }
    /// <summary>
    /// https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
    /// </summary>  
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) //zet het spel terug naar pasieve staat
    {
        if (scene.name == "TitleScreen")
        {
            Debug.Log("Menu");
        }
        if (scene.name == "DynamicQuestions V2") //start een tijd is geld timer
        {
         //   NavigationButton.enabled = true;
       //     NavigationButton.interactable = true;
            Debug.Log("DynamicQuestions");
        }
      
    }
}
