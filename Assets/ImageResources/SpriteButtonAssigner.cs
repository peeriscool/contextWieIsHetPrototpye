using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SpriteButtonAssigner : MonoBehaviour
{
    public List<Sprite> spriteList; // List of sprites to assign

    private Button[] buttons; // Array to store the button references

    private void Awake()
    {
        // Get all the button components in the scene
        buttons = FindObjectsOfType<Button>();

        // Make sure the number of buttons matches the number of sprites in the list
        if (buttons.Length != spriteList.Count)
        {
            Debug.LogError("Number of buttons does not match the number of sprites in the list!");
            return;
        }

        // Assign sprites to buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            // Get the image component of the button
            Image buttonImage = buttons[i].GetComponent<Image>();
            buttons[i].GetComponent<Text>();
            // Assign the corresponding sprite from the list
            buttonImage.sprite = spriteList[i];
        }
    }
}