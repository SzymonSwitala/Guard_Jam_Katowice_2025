using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    [SerializeField] Item item,item2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddItemToList(item);
        }
        if (Input.GetMouseButtonDown(1))
        {
            AddItemToList(item2);
        }
    }
    void AddItemToList(Item item)
    {
        items.Add(item);
    }
}
