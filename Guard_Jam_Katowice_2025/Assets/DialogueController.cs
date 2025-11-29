using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueTextField;
    [SerializeField] private GameObject OptButtonPrefab;
    [SerializeField] private Transform optionsParent;
    public Dialogue dialogue;
    private void Start()
    {
        dialogueTextField.text = dialogue.text;
        GenerateOptions();
    }
    private void GenerateOptions()
    {
        foreach (Transform child in optionsParent)
            Destroy(child.gameObject);

        foreach (var choice in dialogue.choices)
        {
            GameObject buttonObj = Instantiate(OptButtonPrefab, optionsParent);
            OptionButton obtButton = buttonObj.GetComponent<OptionButton>();
            Button btn = obtButton.Button;

            obtButton.Text.text = choice.optionText;
            obtButton.descritption.text = GetDescription(choice);

            Choice captured = choice;

            btn.onClick.AddListener(() => OnChoiceSelected(captured));
        }


    }
    string GetDescription(Choice choice)
    {
        string desc = "";
        if (choice.itemsYouUse.Length > 0)
            desc += "Zużywa: " + string.Join(", ", Array.ConvertAll(choice.itemsYouUse, i => i.name)) + "\n";
        if (choice.itemsYouGet.Length > 0)
            desc += "Daje: " + string.Join(", ", Array.ConvertAll(choice.itemsYouGet, i => i.name)) + "\n";

        desc += $"Hunger: {(choice.hungerChange >= 0 ? "+" : "")}{choice.hungerChange}, " +
                $"Thirst: {(choice.waterChange >= 0 ? "+" : "")}{choice.waterChange}, " +
                $"Morale: {(choice.moraleChange >= 0 ? "+" : "")}{choice.moraleChange}, " +
                $"Temperature: {(choice.temperatureChange >= 0 ? "+" : "")}{choice.temperatureChange}";

        return desc;
    }
    private void OnChoiceSelected(Choice choice)
    {
        var stats = StatisticsManager.Instance;
        var inv = InventoryManager.Instance;

        Debug.Log("Wybrano opcję: " + choice.optionText);

        stats.ChangeHunger(choice.hungerChange);
        stats.ChangeThirst(choice.waterChange);
        stats.ChangeTemperature(choice.temperatureChange);
        stats.ChangeMorale(choice.moraleChange);

        Debug.Log($"H:{stats.hunger} W:{stats.thirst} T:{stats.temperature} M:{stats.morale}");

        foreach (Item item in choice.itemsYouUse)
        {
            if (item != null && inv.HasItem(item.name))
            {
                inv.RemoveItemByName(item.name);
                Debug.Log("Użyto item: " + item.name);
            }
            else if (item != null)
            {
                Debug.LogWarning("Brakuje itemu: " + item.name);
            }
        }

        foreach (Item item in choice.itemsYouGet)
        {
            if (item != null)
            {
                if (!inv.IsInventoryFull())
                {
                    inv.AddItem(item);
                    Debug.Log("Dodano item: " + item.name);
                }
                else
                {
                    Debug.LogWarning("Nie można dodać itemu, inventory pełne: " + item.name);
                }
            }
        }
    }
}

