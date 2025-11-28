using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShoppingCenterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private Button finishShoppingButton;
    private void Start()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged += RefreshShoppingListText;
        RefreshShoppingListText(null);
    }

    private void OnDisable()
    {
        if (InventoryManager.Instance != null)
            InventoryManager.Instance.OnInventoryChanged -= RefreshShoppingListText;
    }

    private void RefreshShoppingListText(List<Item> items)
    {

        textMeshProUGUI.text = "";

        textMeshProUGUI.text += "Lista zakupów: " + "\n";

        if (items!=null)
        {
            foreach (var item in items)
            {
                textMeshProUGUI.text += item.name + "\n";
            }
        }
       

        if (InventoryManager.Instance.isInventoryFull())
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


