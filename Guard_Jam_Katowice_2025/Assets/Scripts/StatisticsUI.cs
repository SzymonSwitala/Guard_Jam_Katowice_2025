using UnityEngine;
using UnityEngine.UI;

public class StatisticsUI : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider thirstSlider;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider temperatureSlider;
    [SerializeField] private Slider moraleSlider;

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
        hungerSlider.value = StatisticsManager.Instance.hunger;
        temperatureSlider.value = StatisticsManager.Instance.temperature;
        moraleSlider.value = StatisticsManager.Instance.morale;
    }
}