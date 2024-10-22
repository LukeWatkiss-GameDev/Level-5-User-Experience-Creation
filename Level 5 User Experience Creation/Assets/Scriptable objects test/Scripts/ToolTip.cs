using TMPro;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public InventoryScriptableOBJ scriptableOBJ;

    public TMP_Text name;
    public TMP_Text description;

    public GameObject objectUnderMouse;

    public Vector3 offset;
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
