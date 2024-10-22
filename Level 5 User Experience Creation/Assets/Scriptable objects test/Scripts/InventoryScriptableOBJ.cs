using System;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/InventoryScriptableOBJ")]
public class InventoryScriptableOBJ : ScriptableObject
{
    public String itemName;
    public String itemDescription;

    public Sprite itemSprite;
}
