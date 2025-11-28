using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public event Action<List<Item>> OnInventoryChanged;
    private List<Item> items = new List<Item>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   public void AddItemToList(Item item)
    {
        items.Add(item);
        Debug.Log("Add item: " + item);
        OnInventoryChanged?.Invoke(items);

    }
}
