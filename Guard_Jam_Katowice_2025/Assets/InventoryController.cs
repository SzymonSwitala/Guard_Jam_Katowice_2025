using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public event Action<List<Item>> OnInventoryChanged;
    private List<Item> items = new List<Item>();
    [SerializeReference] private int maxItemCount;


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
        if (isInventoryFull()) return;

        items.Add(item);
        Debug.Log("Add item: " + item);
        OnInventoryChanged?.Invoke(items);

    }
   public bool isInventoryFull()
    {
        if (items.Count >= maxItemCount)
        {
            Debug.Log("Inventory is full");         
            return true;
            
        }
        else
        {
            Debug.Log("Inventory is not full");
            return false;
        }
    }
   public List<Item> GetInventoryList()
    {
        return items;
    }
}
