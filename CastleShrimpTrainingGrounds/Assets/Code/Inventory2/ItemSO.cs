using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="item",menuName="scriptable objects/Item")]

public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    public GameObject prefab;
    public int maxStackSize;
}
