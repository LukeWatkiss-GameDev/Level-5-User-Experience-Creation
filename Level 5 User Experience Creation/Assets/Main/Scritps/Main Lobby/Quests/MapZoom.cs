using UnityEngine;
using UnityEngine.EventSystems;

public class MapZoom : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    Vector3 mapStartPos;
    Vector3 mapZoomPosition;
    public float zoomAmount;
    public float minZoom;
    public float maxZoom;

    Vector2 curMousePos;
    Vector3 curMapScale;
    Vector3 curMapPos;

    bool canZoom;
    void Start()
    {
        // get and set the starting position of the map
        mapStartPos = transform.localPosition;
        curMapPos = mapStartPos;

        mapZoomPosition = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(canZoom)
        {
            // takes the mouse position and converts it to a position reletive to the map itself
            // i think
            RectTransformUtility.ScreenPointToLocalPointInRectangle(gameObject.GetComponent<RectTransform>(),
                                                                    Input.mousePosition,
                                                                    null,
                                                                    out curMousePos);
            // scroll out 
            if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                // find the current mouse position, map scale and map position
                //curMousePos = Input.mousePosition;
                curMapScale = transform.localScale;
                curMapPos = transform.localPosition;
                // when zooming out lerp the map back to its original position
                curMapPos = Vector3.Lerp(curMapPos,mapStartPos,.05f);         
                curMapScale = new Vector3(curMapScale.x -= zoomAmount + 0.05f, curMapScale.y -= zoomAmount + 0.05f, 0);
            }
            // scroll in 
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                // find the current mouse position, map scale and map position
                curMapScale = transform.localScale;
                curMapPos = transform.localPosition;
                // zoom in towards the current mouse position reletive to the map itself
                curMapPos = Vector3.Lerp(curMapPos,-curMousePos ,.05f);            
                curMapScale = new Vector3(curMapScale.x += zoomAmount,curMapScale.y += zoomAmount,0);
            } 
            // clamp the zoom by the min and max values
            Vector3 clampedScale = new Vector3(Mathf.Clamp(curMapScale.x,minZoom,maxZoom),
                                                Mathf.Clamp(curMapScale.y,minZoom,maxZoom),
                                                0);
                                                
            // clamp the position of the map so it dosent go to far off of the mask and disapear
            // min and max values have been diced through trial and error while zooming the map 
            Vector3 clampedMapPos = new Vector3(Mathf.Clamp(curMapPos.x,-600,600),
                                                Mathf.Clamp(curMapPos.y,-600,600),
                                                0); 
            // apply the clamped values
            // check if the map is at its max zoom, this stops the map moving around when it is fully zoomed in
            // only need to check one scale axis as they are all uniform
            // only check this is the user is still trying to zoom in
            if(transform.localScale.x != maxZoom || Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                transform.localScale = clampedScale;
                transform.localPosition = clampedMapPos;
            }
        }
            
    }
    // these funtions check if the mouse has entered or exited the game object
    public void OnPointerEnter(PointerEventData eventData)
    {
        canZoom = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        canZoom = false;
    }
}
