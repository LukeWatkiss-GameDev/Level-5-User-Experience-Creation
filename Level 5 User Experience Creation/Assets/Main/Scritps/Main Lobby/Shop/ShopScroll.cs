using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShopScroll : MonoBehaviour
{
    public GameObject[] shopPanels;
    public GameObject[] sliderSections;
    public Sprite sliderBarActive;
    public Sprite sliderBarInactive;

    public GameObject currentMiddlePanel;
    public float fadedPanelAlpha;
    float t;
    bool canScroll;
    public float scrollTime;
    public float scrollAmount;
    int scrollCounter = 0; // keeps track of the amount of scrolls up and down
    int panelTracker = 2; // keeps track of which panel is in the middle  - value is set to the middle panels child index

    // Start is called before the first frame update
    void Start()
    {
        canScroll = true;
        FadePanels();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scrollCounter);
        // scroll down
        // check if the user can scroll using the scroll counter and bool
        if(Input.GetAxisRaw("Mouse ScrollWheel") < 0 && canScroll && scrollCounter != -2)  
        {
            canScroll = false;
            // add a delay to the ability to scroll
            StartCoroutine(ScrollDelay());

            MoveShopDown();
        }  
        // scroll up
        
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0 && canScroll && scrollCounter != 2)  
        {
            canScroll = false;
            // add a delay to the ability to scroll
            StartCoroutine(ScrollDelay());

            MoveShopUp();
        }  
    }

    void MoveShopUp()
    {
        // loop through all the panels and move them up by the scroll amount, reletive to the panels current y position
        foreach (GameObject panel in shopPanels)
        {
            float endPos = panel.transform.localPosition.y  + - scrollAmount;
            panel.transform.DOLocalMoveY(endPos,scrollTime);
        }
        scrollCounter++; // Increase scroll counter by 1
        panelTracker--;
        
        UpdatePanels();
    }

    void MoveShopDown()
    {
        // loop through all the panels and move them up by the scroll amount, reletive to the panels current y position
        foreach (GameObject panel in shopPanels)
        {
            float endPos = panel.transform.localPosition.y  + scrollAmount;
            panel.transform.DOLocalMoveY(endPos,scrollTime);
        }
        scrollCounter--; // Reduce scroll counter by 1
        panelTracker++;
        
        UpdatePanels();
    }

    void UpdatePanels()
    {
        currentMiddlePanel = transform.GetChild(panelTracker).gameObject; // update the current middle panel
        FadePanels();
        ChangeSliderSections();
    }

    IEnumerator ScrollDelay()
    {
        // wait untill all the panels have reached their destination then allow scrolling again
        yield return new WaitForSeconds(scrollTime);
        canScroll = true;
    }

    void ChangeSliderSections()
    {
        // loop through all of the slider sections and chek which one corosponds to the current shop panel
        // this is done using the panelTracker int
        foreach (GameObject section in sliderSections)
        {
            if(section.name == (panelTracker + 1).ToString())
            {
                section.GetComponent<Image>().sprite = sliderBarActive;
            }
            else
            {
                section.GetComponent<Image>().sprite = sliderBarInactive;
            }
        }
    }

    void FadePanels()
    {
        t = 0f;
        foreach (GameObject panel in shopPanels)
        {
            if(panel != currentMiddlePanel)
            {
                StartCoroutine(FadePanel(panel.GetComponent<CanvasGroup>(),true));
            }
            else if(panel == currentMiddlePanel)
            {
                StartCoroutine(FadePanel(panel.GetComponent<CanvasGroup>(),false));
            }
        }
    }

    IEnumerator FadePanel(CanvasGroup canvas, bool fadeout)
    {
        float startValue = canvas.alpha;
        if(fadeout)
        {
            // make the canvas non interactable
            canvas.interactable = false;
            // fade out the panels alpha value to the target value
            while(canvas.alpha > fadedPanelAlpha)
            {
                t += 0.6f * Time.deltaTime;
                canvas.alpha =  Mathf.Lerp(startValue,fadedPanelAlpha,t);

                yield return null;
            }

        }

        else if(!fadeout)
        {
            // make the canvas interactable
            canvas.interactable = true;
            // fade in the panels alpha value to the target value
            while(canvas.alpha < 1)
            {
                t += 0.6f * Time.deltaTime;
                canvas.alpha =  Mathf.Lerp(startValue,1f,t);

                yield return null;
            }
        }
        
    } 
}
