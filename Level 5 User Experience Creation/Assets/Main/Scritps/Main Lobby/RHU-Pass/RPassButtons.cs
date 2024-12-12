using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class RPassButtons : MonoBehaviour
{
    public GameObject currentSelectedButton;
   
    void Start()
    {
        // grow the first game object
        GrowOBJ(currentSelectedButton);
    }

    public void SelectButton(GameObject obj)
    {
        // shrink the current selected game object and then grown the object that has just been clicked
        ShrinkOBJ(currentSelectedButton);
        GameObject nextSelectedOBJ = EventSystem.current.currentSelectedGameObject;
        GrowOBJ(nextSelectedOBJ);

    }

    void GrowOBJ(GameObject obj)
    {
        // grow the selected game object and then set it to the current selected game object
        obj.transform.DOScale(1.1f,.5f);
        currentSelectedButton = obj; 
    }

    void ShrinkOBJ(GameObject obj)
    {
        obj.transform.DOScale(1,.5f);
    }
}
