using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public event Action<List<Item>> OnInventoryChanged;

    [SerializeField] private int maxItemCount = 10;
    public List<Item> items = new List<Item>();

    private void Awake()
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

        // Wypełniamy listę pustymi miejscami (null)
        while (items.Count < maxItemCount)
        {
            items.Add(null);
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                OnInventoryChanged?.Invoke(items);
                Debug.Log("Dodano item: " + item.name);
                return true;
            }
        }

        Debug.Log("Inventory jest pełne!");
        return false;
    }

    public bool RemoveItemByName(string itemName)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null && items[i].name == itemName)
            {
                items[i] = null;
                OnInventoryChanged?.Invoke(items);
                Debug.Log($"Item '{itemName}' został usunięty.");
                return true;
            }
        }

        Debug.Log($"Item '{itemName}' nie został znaleziony.");
        return false;
    }

    public List<Item> GetInventoryList()
    {
        return items;
    }

    public bool HasItem(string itemName)
    {
        foreach (Item item in items)
        {
            if (item != null && item.name == itemName)
                return true;
        }
        return false;
    }

    public bool IsInventoryFull()
    {
        foreach (Item item in items)
        {
            if (item == null) return false;
        }
        return true;
    }
    public int GetMaxItemCount()
    {
        return maxItemCount;
    }
}