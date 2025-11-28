using System;
using System.Collections.Generic;
using UnityEngine;

public class HomeShelvesController : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] slotPositions;
    private void Start()
    {
        RefreshShelves(null);

        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged += RefreshShelves;
    }

    private void OnDisable()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged -= RefreshShelves;
    }

    private void RefreshShelves(List<Item> list)
    {
        List<Item> inventory = InventoryManager.Instance.GetInventoryList();

        for (int i = 0; i < slotPositions.Length; i++)
        {
            if (i < inventory.Count)
            {
                if (inventory[i]==null)
                {
                    slotPositions[i].sprite = null;
                }
                else
                {
                    slotPositions[i].sprite = inventory[i].sprite;
                }
            }
            else
            {
                slotPositions[i].sprite = null;
            }
        }
    }
}