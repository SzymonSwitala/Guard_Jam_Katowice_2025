using UnityEngine;
using System;
using System.Collections.Generic;

public class StatisticsManager : MonoBehaviour
{
    public static StatisticsManager Instance;

    public event Action OnAnyStatZero;

    public enum StatType { Thirst, Hunger, Temperature, Morale }

    private Dictionary<StatType, float> stats = new Dictionary<StatType, float>
    {
        { StatType.Thirst, 100 },
        { StatType.Hunger, 100 },
        { StatType.Temperature, 100 },
        { StatType.Morale, 100 }
    };

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public float GetStat(StatType type) => stats[type];

    public void Add(StatType type, float value)
    {
        stats[type] = Mathf.Clamp(stats[type] + value, 0, 100);
        CheckLoseCondition();
    }

    public void Sub(StatType type, float value)
    {
        stats[type] = Mathf.Clamp(stats[type] - value, 0, 100);
        CheckLoseCondition();
    }

    private void CheckLoseCondition()
    {
        foreach (var stat in stats.Values)
        {
            if (stat <= 0)
            {
                OnAnyStatZero?.Invoke();
                Debug.Log("GAME OVER – a stat reached zero!");
                break;
            }
        }
    }
}