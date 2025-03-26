using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemInstance
{    
    public ItemData itemType;
    public int condition;
    public int ammo;
    public ItemData newItemType;
    public List<ItemInstance> items = new();

    public void Start()
    {
        items.Add(new ItemInstance(newItemType));
    }
    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
        condition = itemData.startingCondition;
        ammo = itemData.startingAmmo;
    }
}