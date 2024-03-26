using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reference link: https://gamedevbeginner.com/how-to-make-an-inventory-system-in-unity/

[CreateAssetMenu(fileName = "NewInventoryItemData", menuName = "InventoryItemData")]
[System.Serializable]
public class InventoryItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject model;
    [TextArea]
    public string description;


    public Sprite GetSprite() {
        return icon;
    }

}