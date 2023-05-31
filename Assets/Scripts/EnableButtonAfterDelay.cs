using UnityEngine;
using UnityEngine.UI;

public class EnableButtonAfterDelay : MonoBehaviour
{
    Button targetButton;
    public float delay = 5f;

    private float timer;
    private float lasttimer;
    private void Start()
    {
        targetButton = this.gameObject.GetComponent<Button>();
        // Disable the button initially
        targetButton.interactable = false;

        // Start the timer
        timer = 0f;
    }

    private void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;
        if(timer >= lasttimer)
        { // int seconds = Mathf.FloorToInt(timer % 60f);
            lasttimer = timer;
            int sec = (int)delay - Mathf.FloorToInt(timer % 60f) ;
            this.gameObject.GetComponentInChildren<Text>().text = string.Format("{0:00}", sec); //string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        // Check if the delay has passed
        if (timer >= delay)
        {
            // Enable the button
            targetButton.interactable = true;

            // Disable this script to stop further updates
            enabled = false;
            this.gameObject.GetComponentInChildren<Text>().text = "confirm";
        }
    }
}
