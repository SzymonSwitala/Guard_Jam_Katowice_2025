using System;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public static StatisticsManager Instance;

    public event Action OnAnyStatZero;
    public event Action OnStatsChanged;

    [Header("Stats")]
    public int thirst = 10;
    public int hunger = 10;
    public int temperature = 10;
    public int morale = 10;

    [Header("Max Values")]
    public int maxThirst = 10;
    public int maxHunger = 10;
    public int maxTemperature = 10;
    public int maxMorale = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InvokeChanged()
    {
        OnStatsChanged?.Invoke();
        CheckIfAnyStatZero();
    }

    private void CheckIfAnyStatZero()
    {
        if (thirst <= 0 || hunger <= 0 || temperature <= 0 || morale <= 0)
        {
            OnAnyStatZero?.Invoke();
        }
    }

    public void ChangeThirst(int amount)
    {
        thirst = Mathf.Clamp(thirst + amount, 0, maxThirst);
        InvokeChanged();
    }

    public void ChangeHunger(int amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0, maxHunger);
        InvokeChanged();
    }

    public void ChangeTemperature(int amount)
    {
        temperature = Mathf.Clamp(temperature + amount, 0, maxTemperature);
        InvokeChanged();
    }

    public void ChangeMorale(int amount)
    {
        morale = Mathf.Clamp(morale + amount, 0, maxMorale);
        InvokeChanged();
    }
}