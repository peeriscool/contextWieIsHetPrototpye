using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    //[System.Serializable]
    public SceneManager SceneManager;
    
    void Start()
    {
        SceneManager = new SceneManager();
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        //update visuals
    }

    public void StartScene(string Scene)
    {
        SceneManager.LoadScene(Scene,LoadSceneMode.Single);
    }
}
