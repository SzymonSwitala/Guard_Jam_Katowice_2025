using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsUI : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider thirstSlider;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider temperatureSlider;
    [SerializeField] private Slider moraleSlider;

    [SerializeField] private TextMeshProUGUI thirstTextField;
    [SerializeField] private TextMeshProUGUI hungerTextField;
    [SerializeField] private TextMeshProUGUI temperatureTextField;
    [SerializeField] private TextMeshProUGUI moraleTextField;

    private void Start()
    {
        SetUpBars();
        UpdateSliders();
    }

    private void Update()
    {

        UpdateSliders();
    }
    private void SetUpBars()
    {
        var stats = StatisticsManager.Instance;

        thirstSlider.maxValue = stats.maxThirst;
        hungerSlider.maxValue = stats.maxHunger;
        temperatureSlider.maxValue = stats.maxTemperature;
        moraleSlider.maxValue = stats.maxMorale;
    }
    private void UpdateSliders()
    {
        if (StatisticsManager.Instance == null) return;

        thirstSlider.value = StatisticsManager.Instance.thirst;
        thirstTextField.text = StatisticsManager.Instance.thirst + "/" + StatisticsManager.Instance.maxThirst;

        hungerSlider.value = StatisticsManager.Instance.hunger;
        hungerTextField.text = StatisticsManager.Instance.hunger + "/" + StatisticsManager.Instance.maxHunger;

        temperatureSlider.value = StatisticsManager.Instance.temperature;
        temperatureTextField.text = StatisticsManager.Instance.temperature + "/" + StatisticsManager.Instance.maxTemperature;

        moraleSlider.value = StatisticsManager.Instance.morale;
        moraleTextField.text = StatisticsManager.Instance.morale + "/" + StatisticsManager.Instance.maxMorale;
    }
}