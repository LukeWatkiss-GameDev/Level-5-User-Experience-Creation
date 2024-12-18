using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RPassButtons : MonoBehaviour
{
    RPassItemGenerator rPassItemGeneratorScript;
    public GameObject currentSelectedButton;
    public GameObject currentShownItem;
    public GameObject RHUpassItemHolder;

    public GameObject rPassBuyScreen;
    public Camera rPassCamera;

    public void SelectButton()
    {
        // shrink the current selected game object and then grown the object that has just been clicked
        if(currentSelectedButton != null)
        {
            ShrinkOBJ(currentSelectedButton);
        }
        GameObject nextSelectedOBJ = EventSystem.current.currentSelectedGameObject;
        GrowOBJ(nextSelectedOBJ);

    }

    public void GrowOBJ(GameObject obj)
    {
        // grow the selected game object and then set it to the current selected game object
        obj.transform.DOScale(1.1f,.5f);
        currentSelectedButton = obj; 
        currentSelectedButton.GetComponent<Button>().interactable = false;
    }

    void ShrinkOBJ(GameObject obj)
    {
        // shrink the obj back to its original scale
        obj.GetComponent<Button>().interactable = true;
        obj.transform.DOScale(1,.5f);
    }

    public void ChangeShownItem(int index)
    {
        // change the item that is shown through the render texture
        if(currentShownItem != null)
        {
            HideItem(currentShownItem);
        }
        ShowItem(RHUpassItemHolder.transform.GetChild(index).gameObject);
        
    }

    void ShowItem(GameObject obj)
    {
        obj.SetActive(true);
        currentShownItem = obj;
    }

    void HideItem(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void SwapToRhuPassBuy()
    {
        // swap to the next rhu pass screen
        rPassBuyScreen.SetActive(true);
        rPassCamera.gameObject.SetActive(true);
    }

}
