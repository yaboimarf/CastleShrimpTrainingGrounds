using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public ItemSO itemScriptableObject;

    [SerializeField] Image iconImage;

    private void Update()
    {
        iconImage.sprite = itemScriptableObject.icon;
    }
}
