using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeTracker : MonoBehaviour
{
    public Text timeText;

    private float elapsedTime;

    void Start()
    {
    elapsedTime = 0f;    
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the elapsed time by the time elapsed since the last frame
        elapsedTime += Time.deltaTime;

        // Convert the elapsed time to minutes and seconds
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);

        // Update the UI text element
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
