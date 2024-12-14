using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RPassItemGenerator : MonoBehaviour
{
    RPassButtons rPassButtonsScript;
    int itemsToGenerate;

    RPScriptableObject RPassScriptableList;

    public GameObject listParent;
    public GameObject itemPrefab;


    void Start()
    {
        rPassButtonsScript = GetComponent<RPassButtons>();
        RPassScriptableList = Resources.Load<RPScriptableObject>("RHUpass"); // grab the scriptable object list
        itemsToGenerate = RPassScriptableList.listOfPassItems.Length;
        for (int i = 0; i < itemsToGenerate; i++)
        {
            // generate a new item
            GenerateItem(i);

        }
        
    }

    void GenerateItem(int index)
    {
        // create new item obj and parent to the grid content
        GameObject itemHolder = Instantiate(itemPrefab,listParent.transform);
        RHUpassItem itemScriptable = RPassScriptableList.listOfPassItems[index];
        // Find the button gameobject (This is also used to find the children of this object)
        Transform item = itemHolder.transform.Find("RP tier button");
        // add onClick methods to the button
        item.GetComponent<Button>().onClick.AddListener(() => rPassButtonsScript.SelectButton());
        item.GetComponent<Button>().onClick.AddListener(() => rPassButtonsScript.ChangeShownItem(index));
        // Find the image and set the new sprite
        Transform icon = item.Find("Icon");
        icon.GetComponent<Image>().sprite = itemScriptable.itemSprite;
        // scale the sprite and set navtive size to avoid sprites stretching but still make sure they fit in the box
        icon.localScale = new Vector3(itemScriptable.spriteScale,
                                    itemScriptable.spriteScale,
                                    itemScriptable.spriteScale);

        icon.GetComponent<Image>().SetNativeSize();
        
        // Set the items tier number
        item.Find("Tier").GetComponent<TMP_Text>().SetText("Tier " + (index + 1));

        // Set the items name
        item.Find("Item name").GetComponent<TMP_Text>().SetText(itemScriptable.itemName);

        // Set the items Type
        if(itemScriptable.itemName != "FullSkin")
        {
            item.Find("Item Type").GetComponent<TMP_Text>().SetText("(" + itemScriptable.itemType.ToString() + " Cosmetic)");
        }
        else
        {
            item.Find("Item Type").GetComponent<TMP_Text>().SetText("(Full Skin)");
        }

        // if this is the first item created grow the obj and activate the first render texture item
        if(index == 0)
        {   
            rPassButtonsScript.GrowOBJ(item.gameObject);
            rPassButtonsScript.ChangeShownItem(0);
        }
    }

}
