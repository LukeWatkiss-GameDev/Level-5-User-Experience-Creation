using UnityEngine;
using UnityEngine.EventSystems;

public class MapMarker : MonoBehaviour
{
    public GameObject mapMarker;

    void Update()
    {
        // check for mouse input
        if(mapMarker != null && Input.GetMouseButtonDown(0))
        {
            // check if the script has detected a clicked object
            GameObject clickedOBJ = EventSystem.current.currentSelectedGameObject;
            // check if clicked object is = null to avoid errors
            if(clickedOBJ != null &&clickedOBJ.name == "Map")
            {
                // move the map marker to the mouse position
                mapMarker.transform.position = Input.mousePosition;      
                // activate the map marker
                mapMarker.SetActive(true);

            }
            else if(clickedOBJ != null &&clickedOBJ.name == "Map Marker")
            {
                // if the map marker is clicked remove the marker
                mapMarker.SetActive(false);
            }
        }
    }
}
