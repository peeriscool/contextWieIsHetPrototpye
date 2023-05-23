using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonGrabber : MonoBehaviour
{
    private bool isGrabbing = false; // Tracks whether the button is being grabbed
    [SerializeField]
    private GameObject grabbedButton; // Reference to the grabbed button
    private Vector3 offset;
    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position to detect if a button was clicked
            Debug.Log("Click");

            Debug.DrawLine(Camera.main.ScreenToWorldPoint(Camera.main.transform.position), Input.mousePosition, Color.red, 3f,true);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Camera.main.transform.position), Input.mousePosition);
            if (hit.collider != null)
            {
                Debug.Log("Hit");
                // Check if the clicked object has a Button component
                Button button = hit.collider.GetComponent<Button>();
                if (button != null)
                {
                    // Set the grabbed button and flag the grabbing state
                    grabbedButton = button.gameObject;
                    isGrabbing = true;
                    
                    offset = button.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Debug.Log(button.name + offset.ToString());
                    // rectTransform = GetComponent<RectTransform>();
                }
                hit.transform.gameObject.AddComponent<ObjectMover>();
            }
        }
        //if(isGrabbing && grabbedButton != null)
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), mousePos, Color.red, 3f);
        //    grabbedButton.transform.position = new Vector3(mousePos.x + offset.x, mousePos.y + offset.y, transform.position.z);
        //}
        //if (Input.GetMouseButtonUp(0) && isGrabbing)
        //{

        //    // Check if the button is still being grabbed
        //    if (grabbedButton != null)
        //    {
        //        // Perform the button click action
        //        grabbedButton.GetComponent<Button>().onClick.Invoke();
        //        grabbedButton = null;
        //    }

        //    // Reset the grabbing state
        //    isGrabbing = false;
        //}
    }
}