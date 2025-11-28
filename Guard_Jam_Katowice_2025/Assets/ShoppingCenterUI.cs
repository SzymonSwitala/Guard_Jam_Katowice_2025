using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShoppingCenterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    private void Start()
    {
        if (InventoryManager.Instance != null)
        InventoryManager.Instance.OnInventoryChanged += RefreshShoppingListText;
    }

    private void OnDisable()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged -= RefreshShoppingListText;
    }

    private void RefreshShoppingListText(List<Item> items)
    {
        Debug.Log("dupa");
        textMeshProUGUI.text = "";

        textMeshProUGUI.text += "Lista zakupów: " + "\n";
        foreach (var item in items)
        {
            textMeshProUGUI.text += item.name + "\n";
        }
    }
}
