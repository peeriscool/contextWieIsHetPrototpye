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
        Debug.Log("using canvas Raycast");
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
                if (hitObject.GetComponent<Button>())
                {
                    if (! hitObject.GetComponent<ObjectMover>())
                    {
                        hitObject.AddComponent<ObjectMover>();
                        hitObject.GetComponent<Button>().interactable = false;
                    }
                }
            }
        }
    }

    private void PerformScreenSpaceCameraRaycast(Ray ray)
    {
        Debug.Log("using screen raycast");
    }

    private void PerformWorldSpaceRaycast(Ray ray)
    {
        Debug.Log("using world raycast");
    }

    /// <summary>
    /// assign the playingfield
    /// </summary>
    /// <param name="_canvas">assign the playingfield</param>
    public void assignCanvas(Canvas _canvas)
    {
        canvas = _canvas;
    }
    /// <summary>
    /// assign the camera for raycast
    /// </summary>
    /// <param name="_camera">assign the camera for raycast</param>
    public void assignCamera(Camera _camera)
    {
        raycastCamera = _camera;
    }
}