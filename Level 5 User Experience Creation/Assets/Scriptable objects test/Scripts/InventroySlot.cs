using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventroySlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public MouseCheck mouseCheckScript;

    public InventoryScriptableOBJ[] inventoryScriptableOBJ;

    public InventoryScriptableOBJ currentScriptableOBJ;
    Sprite itemSprite;
    public Image itemImageSlot;

    void Start()
    {
        int randomNum = Random.Range(0,inventoryScriptableOBJ.Length - 1);
        itemSprite = inventoryScriptableOBJ[randomNum].itemSprite;
        itemImageSlot.overrideSprite = itemSprite;
        currentScriptableOBJ = inventoryScriptableOBJ[randomNum];
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        
        mouseCheckScript.objectUnderMouse = eventData.pointerEnter.gameObject;
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseCheckScript.objectUnderMouse = null;
        
    }
}
