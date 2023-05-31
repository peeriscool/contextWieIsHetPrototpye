using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectMover : MonoBehaviour, IDragHandler
{
    public bool useRectTransform;
    private RectTransform rectTransform; // Reference to the RectTransform component of the object being moved
    private Transform transform;
    private void Awake()
    {
        if(useRectTransform)
        {
            rectTransform = GetComponent<RectTransform>(); // Get the RectTransform component
        }
        else
        {
            transform = GetComponent<Transform>();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("On Drag");
        if(useRectTransform)
        {
            if (rectTransform != null)
            {
                rectTransform.anchoredPosition += eventData.delta; // Update the anchored position of the RectTransform based on the drag delta
            }
        }
        else
        {
            
            if (transform != null)
            {
                Vector3 movement = new Vector3();
                movement.x += eventData.delta.x * Time.deltaTime;
                movement.y += eventData.delta.y * Time.deltaTime;

                transform.position += movement;
            }
        }
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag release");
        //  this.gameObject.GetComponent<Button>().interactable = true;
        //  this._spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
//#if UNITY_EDITOR
//    private void Reset()
//    {
//        this._spriteRenderer = this.GetComponent<SpriteRenderer>();
//    }
//#endif
}
