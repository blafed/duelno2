using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
public static class InputUtils
{
    static List<RaycastResult> raycastResults = new();


    public static bool IsPointerOverCollider2D(Camera camera)
    {
        //check if the mouse was clicked over a collider (2d)

        // if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        // {
        RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        return hit.collider != null;
        // }
        // return false;
    }

    public static bool IsPointerOverUIElement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Perform a new raycast when the mouse button is pressed.
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            return results.Count > 0;
        }
        else if (Input.GetMouseButton(0))
        {
            // Perform a new raycast every frame while the mouse button is held down.
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);

            return results.Count > 0;
        }
        else
        {
            // Reset the raycast results when the mouse button is released.
            EventSystem.current.RaycastAll(new PointerEventData(EventSystem.current), raycastResults);
            raycastResults.Clear();

            return false;
        }
    }
    // public static bool IsPointerOverUIElement()
    // {
    //     var eventSystemRaysastResults = GetEventSystemRaycastResults();
    //     for (int index = 0; index < eventSystemRaysastResults.Count; index++)
    //     {
    //         RaycastResult curRaysastResult = eventSystemRaysastResults[index];

    //         if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
    //             return true;
    //     }

    //     return false;
    // }

    // ///Gets all event systen raycast results of current mouse or touch position.
    // static List<RaycastResult> GetEventSystemRaycastResults()
    // {
    //     PointerEventData eventData = new PointerEventData(EventSystem.current);
    //     eventData.position = Input.mousePosition;

    //     List<RaycastResult> raysastResults = new List<RaycastResult>();
    //     EventSystem.current.RaycastAll(eventData, raysastResults);

    //     return raysastResults;
    // }
}