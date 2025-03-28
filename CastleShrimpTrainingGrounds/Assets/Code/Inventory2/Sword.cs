using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public string itemName;
    public GameObject sword;

    public void Start()
    {
        itemName = "Sword";
    }
    public void ItemPickedUp()
    {
        Destroy(sword);
    }
}

