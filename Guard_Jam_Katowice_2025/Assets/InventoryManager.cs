using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public event Action<List<Item>> OnInventoryChanged;
    public List<Item> items = new List<Item>();
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
    public bool HasItem(string itemName)
    {
        foreach (Item item in items)
        {
            if (item.name == itemName)
            {
                return true;
            }
        }
        return false;
    }
    public void RemoveLastItem()
    {
        if (items.Count > 0)
        {
            items.RemoveAt(items.Count - 1);
            OnInventoryChanged?.Invoke(items);
            Debug.Log("Ostatni item został usunięty.");
        }
        else
        {
            Debug.Log("Lista jest pusta, nie ma co usuwać.");
        }
    }

    // Usuń item po nazwie
    public bool RemoveItemByName(string itemName)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].name == itemName) // lub item.itemName
            {
                items.RemoveAt(i);
                Debug.Log($"Item '{itemName}' został usunięty.");
                OnInventoryChanged?.Invoke(items);
                return true; // zwracamy true jeśli udało się usunąć
            }
        }
        Debug.Log($"Item '{itemName}' nie został znaleziony.");
        return false; // zwracamy false jeśli item nie istnieje
    }
}
