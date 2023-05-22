using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class PublicFunctions
{
    public static void StartScene(string Scene) //single load scenes
    {
        //  Debug.Log("Going to Scene: " + Scene);
        SceneManager.LoadScene(Scene, LoadSceneMode.Single);
    }
    public static void AppendScene(string Scene) //single load scenes
    {
        //  Debug.Log("Going to Scene: " + Scene);
        SceneManager.LoadScene(Scene, LoadSceneMode.Additive);
    }

}
