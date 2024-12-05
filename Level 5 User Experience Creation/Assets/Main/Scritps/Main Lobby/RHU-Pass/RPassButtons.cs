using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class RPassButtons : MonoBehaviour
{
    public GameObject currentSelectedOBJ;
    public GameObject currenSelectedSprite;
    void Start()
    {
        // grow the first game object
        GrowOBJ(currentSelectedOBJ);
    }

    public void SelectButton()
    {
        // shrink the current selected game object and then grown the object that has just been clicked
        ShrinkOBJ(currentSelectedOBJ);
        GameObject nextSelectedOBJ = EventSystem.current.currentSelectedGameObject;
        GrowOBJ(nextSelectedOBJ);

    }

    void GrowOBJ(GameObject obj)
    {
        // grow the selected game object and then set it to the current selected game object
        obj.transform.DOScale(1.1f,.5f);
        currentSelectedOBJ = obj; 
    }

    void ShrinkOBJ(GameObject obj)
    {
        obj.transform.DOScale(1,.5f);
    }
}
