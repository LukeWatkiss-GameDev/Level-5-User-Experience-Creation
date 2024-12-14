using UnityEngine;

[CreateAssetMenu(fileName = "RHUpass", menuName = "ScriptableObjects/RHUpassItems")]
public class RPScriptableObject : ScriptableObject
{
    public RHUpassItem[] listOfPassItems; // array to hold all the created scriptable objects
}

public enum ItemType
{
    // list of item types
    Mouth,
    FullSkin,
    Head,
    Hand,
    eye,
    Misc
}

[System.Serializable]
public class RHUpassItem
{
    // contents of the scriptable object
    public string itemName;
    public ItemType itemType;
    public Sprite itemSprite;
    public float spriteScale;
}
