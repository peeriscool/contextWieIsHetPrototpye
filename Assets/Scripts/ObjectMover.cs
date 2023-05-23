using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectMover : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform; // Reference to the RectTransform component of the object being moved

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>(); // Get the RectTransform component
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition += eventData.delta; // Update the anchored position of the RectTransform based on the drag delta
        }
    }
}
