using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShoppingCenterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private Button finishShoppingButton;
    [SerializeField] private TextMeshProUGUI itemCountTextField;
    private void Start()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged += RefreshShoppingListText;

        RefreshShoppingListText(InventoryManager.Instance?.GetInventoryList());
    }

    private void OnDisable()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged -= RefreshShoppingListText;
    }

    private void RefreshShoppingListText(List<Item> items)
    {
        int validItemCount = items != null ? items.Count(i => i != null) : 0;
        int maxItemCount = InventoryManager.Instance != null ? InventoryManager.Instance.GetMaxItemCount() : 0;

        itemCountTextField.text = $"{validItemCount}/{maxItemCount}";

        textMeshProUGUI.text = "Lista zakupów:\n";

        if (items != null)
        {
            var groupedItems = items
                .Where(i => i != null)
                .GroupBy(i => i.name)
                .Select(g => new { Name = g.Key, Count = g.Count() });

            foreach (var item in groupedItems)
            {
                textMeshProUGUI.text += $"• {item.Name} x{item.Count}\n";
            }
        }

        if (InventoryManager.Instance != null && InventoryManager.Instance.IsInventoryFull())
        {
            finishShoppingButton.gameObject.SetActive(true);
        }
        else
        {
            finishShoppingButton.gameObject.SetActive(false);
        }
    }

    public void ShoppingFinished()
    {
        SceneManager.LoadScene("Home");
    }
}
