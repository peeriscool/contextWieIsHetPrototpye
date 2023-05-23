using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasRaycaster : MonoBehaviour
{
    public Camera raycastCamera; // Reference to the camera used for raycasting
    public Canvas canvas; // Reference to the canvas to perform the raycast on
    [SerializeField]
    private float rayCastDistance = 1250f;
    private RaycastHit hitObject;
   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse is over the canvas
            if (IsMouseOverCanvas())
            {
                // Perform the raycast
                RaycastToCanvas();
            }
        }
    }

    private bool IsMouseOverCanvas()
    {
        // Check if the mouse is over the canvas
        if (EventSystem.current != null)
        {
            return EventSystem.current.IsPointerOverGameObject();
        }

        return false;
    }

    private void RaycastToCanvas()
    {
        if (raycastCamera != null && canvas != null)
        {
            // Create a ray from the camera to the mouse position
            Ray ray = raycastCamera.ScreenPointToRay(Input.mousePosition);

            // Perform the raycast in screen space
            if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            {
                PerformScreenSpaceOverlayRaycast(ray);
            }
            else if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                PerformScreenSpaceCameraRaycast(ray);
            }
            else if (canvas.renderMode == RenderMode.WorldSpace)
            {
                PerformWorldSpaceRaycast(ray);
            }
        }
    }

    private void PerformScreenSpaceOverlayRaycast(Ray ray)
    {
        Debug.Log("overlay");
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        if (raycastResults.Count > 0)
        {
            // Loop through the raycast results to process the UI elements hit by the ray
            foreach (var result in raycastResults)
            {
                // Process the hit UI element as desired
                GameObject hitObject = result.gameObject;
                Debug.Log("Hit UI element: " + hitObject.name);
                if(hitObject.GetComponent<Button>())
                {
                    hitObject.AddComponent<ObjectMover>();
                }
            }
        }
    }

    private void PerformScreenSpaceCameraRaycast(Ray ray)
    {
        Debug.Log("screen");
    }

    private void PerformWorldSpaceRaycast(Ray ray)
    {
        Debug.Log("world");
    }
    public void assignCanvas(Canvas _canvas)
    {
        canvas = _canvas;
    }
    public void assignCamera(Camera _camera)
    {
        raycastCamera = _camera;
    }
}