using TMPro;
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
            TextMeshProUGUI text = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            Button btn = buttonObj.GetComponent<Button>();

            text.text = choice.optionText;

            // WIEEEEELKA UWAGA: zamykamy zmienną choice w lambda
            Choice captured = choice;

            btn.onClick.AddListener(() => OnChoiceSelected(captured));
        }
    }
    private void OnChoiceSelected(Choice choice)
    {

        Debug.Log("Wybrano opcję: " + choice.optionText);
     
        StatisticsManager stats = StatisticsManager.Instance;

        stats.ChangeHunger(choice.hungerChange);
        stats.ChangeThirst(choice.waterChange);
        stats.ChangeTemperature(choice.temperatureChange);
        stats.ChangeMorale(choice.moraleChange);

        Debug.Log($"H:{stats.hunger} W:{stats.thirst} T:{stats.temperature} M:{stats.morale}");

    }
}

