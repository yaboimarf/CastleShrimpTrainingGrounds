using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> items = new List<string>();
    public Sword sword;
    public GameObject swordObject;

    public void Update()
    {
        ItemDrop();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Sword>())
        {
            items.Add(sword.itemName);
            Destroy(swordObject);
        }
    }
    public void ItemDrop()
    {
        if (Input.GetKeyDown("Q"))
        {

        }
    }
}
