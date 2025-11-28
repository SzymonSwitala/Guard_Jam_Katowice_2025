using System.Collections.Generic;
using UnityEngine;

public class HomeShelvesController : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] slotPositions;

    private void Start()
    {
        List<Item> inventory = InventoryManager.Instance.GetInventoryList();

        for (int i = 0; i < inventory.Count && i < slotPositions.Length; i++)
        {
            slotPositions[i].sprite = inventory[i].sprite;
        }
    }
}
