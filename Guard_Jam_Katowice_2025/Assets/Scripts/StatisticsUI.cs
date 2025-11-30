using UnityEngine;

public class StatisticsUI : MonoBehaviour
{
    [SerializeField] private StatBar thirstStatBar;
    [SerializeField] private StatBar hungerStatBar;
    [SerializeField] private StatBar temperatureStatBar;
    [SerializeField] private StatBar moraleStatBar;

    private void Start()
    {
        SetUpBars();
        StatisticsManager.Instance.OnStatsChanged += UpdateUI;
    }

    private void OnDestroy()
    {
        if (StatisticsManager.Instance != null)
            StatisticsManager.Instance.OnStatsChanged -= UpdateUI;
    }

    private void SetUpBars()
    {
        var s = StatisticsManager.Instance;

        thirstStatBar.SetUpSlider(s.thirst, s.maxThirst);
        hungerStatBar.SetUpSlider(s.hunger, s.maxHunger);
        temperatureStatBar.SetUpSlider(s.temperature, s.maxTemperature);
        moraleStatBar.SetUpSlider(s.morale, s.maxMorale);
    }

    private void UpdateUI()
    {
        var s = StatisticsManager.Instance;

        thirstStatBar.UpdateValue(s.thirst);
        hungerStatBar.UpdateValue(s.hunger);
        temperatureStatBar.UpdateValue(s.temperature);
        moraleStatBar.UpdateValue(s.morale);
    }
}