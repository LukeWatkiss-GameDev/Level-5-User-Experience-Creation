using TMPro;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public InventoryScriptableOBJ scriptableOBJ;
    public TMP_Text name;
    public TMP_Text description;
    public GameObject objectUnderMouse;
    public Vector3 offset;
    
    void Update()
    {
        if(scriptableOBJ != null)
        {
            name.SetText(scriptableOBJ.itemName);
            description.SetText(scriptableOBJ.itemDescription);
        }
        transform.position = Input.mousePosition + offset;
    }
}
