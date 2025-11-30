using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueTextField;
    [SerializeField] private GameObject OptButtonPrefab;
    [SerializeField] private Transform optionsParent;
    [SerializeField] private List<Dialogue> dialogues = new List<Dialogue>();
    [SerializeField] private Animator avatarAnimator;
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private TextMeshPro calendarTextField;

    private int currentDialogueIndex = 0;
    private void Start()
    {
        GetNewDialog();
    }
    void GetNewDialog()
    {
        if (currentDialogueIndex >= dialogues.Count)
        {
            gameOverUI.ShowGameOver();
            return;
        }

        Dialogue dialogue = dialogues[currentDialogueIndex];
        avatarAnimator.Play(dialogue.avatarAnim.name);
        currentDialogueIndex++;
        calendarTextField.text = currentDialogueIndex.ToString();
        GenerateNewDialogue(dialogue);


    }
    public void GenerateNewDialogue(Dialogue dialogue)
    {
        dialogueTextField.text = dialogue.text;
        GenerateOptions(dialogue);
    }

    private void GenerateOptions(Dialogue dialogue)
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

            bool canSelect = HasRequiredItems(captured);
            Debug.Log(canSelect);
            btn.interactable = canSelect;
            obtButton.Text.color = canSelect ? Color.white : Color.gray;
            obtButton.descritption.color = canSelect ? Color.white : Color.gray;

            btn.onClick.AddListener(() => OnChoiceSelected(captured));
        }


    }
    private bool HasRequiredItems(Choice choice)
    {
        var inv = InventoryManager.Instance;

        foreach (Item item in choice.itemsYouUse)
        {
            if (item != null && !inv.HasItem(item.name))
                return false;
        }

        return true;
    }
    string GetDescription(Choice choice)
    {
        string desc = "";
        if (choice.itemsYouUse.Length > 0)
            desc += "Zużywa: " + string.Join(", ", Array.ConvertAll(choice.itemsYouUse, i => i.name)) + "\n";
        if (choice.itemsYouGet.Length > 0)
            desc += "Daje: " + string.Join(", ", Array.ConvertAll(choice.itemsYouGet, i => i.name)) + "\n";

        // funkcja pomocnicza do formatowania statów
        string FormatStat(string label, int value)
        {
            if (value == 0) return ""; // NIE wyświetlaj zer

            string color = value > 0 ? "green" : "red";
            string sign = value > 0 ? "+" : "";

            return $"{label}: <color={color}>{sign}{value}</color>, ";
        }

        desc +=
            FormatStat("Nawodnienie", choice.waterChange) +
            FormatStat("Najedzenie", choice.hungerChange) +
            FormatStat("Temperatura", choice.temperatureChange) +
            FormatStat("Morale", choice.moraleChange);

        // usuwa ostatni przecinek i spację jeśli są
        return desc.Trim().TrimEnd(',');
    }
    private void OnChoiceSelected(Choice choice)
    {
        GetNewDialog();
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

