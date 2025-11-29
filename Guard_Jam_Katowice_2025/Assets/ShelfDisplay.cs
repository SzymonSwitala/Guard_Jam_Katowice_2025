using System.Collections.Generic;
using UnityEngine;

public class ShelfDisplay : MonoBehaviour
{
    [Header("Sloty na półce")]
    [SerializeField] private Transform[] slots;
    [Header("Sprite pustego slotu")]
    [SerializeField] private Sprite emptySprite;

    private void OnEnable()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged += RefreshShelf;
    }

    private void OnDisable()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged -= RefreshShelf;
    }

    private void Start()
    {
        RefreshShelf(InventoryManager.Instance.GetInventoryList());
    }

    private void RefreshShelf(List<Item> items)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            SpriteRenderer sr = slots[i].GetComponent<SpriteRenderer>();
            if (sr == null) continue;

            if (i < items.Count && items[i] != null)
            {
                sr.sprite = items[i].sprite;
            }
            else
            {
                sr.sprite = emptySprite;
            }
        }
    }
}