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
        // Ustawienie sliderów na początkowe wartości
        UpdateSliders();
    }

    private void Update()
    {
        // Aktualizacja sliderów w czasie rzeczywistym
        UpdateSliders();
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