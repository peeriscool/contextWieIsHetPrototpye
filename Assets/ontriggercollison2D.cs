using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontriggercollison2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D _col)
    {
        if(_col.gameObject.tag == "kaart")
        {
            Debug.Log("Detected: " + _col.gameObject.name + " Is this correct?");
        }
    }
}
