using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCheck : MonoBehaviour
{
    public ToolTip toolTipScript;
    public GameObject toolTipPopUp;
    public GameObject objectUnderMouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objectUnderMouse!= null)
        {
            toolTipScript.scriptableOBJ = objectUnderMouse.GetComponentInParent<InventroySlot>().currentScriptableOBJ;
            toolTipPopUp.SetActive(true);
        }
        else
        {
            toolTipScript.scriptableOBJ = null;
            toolTipPopUp.SetActive(false);
        }
    }
}
