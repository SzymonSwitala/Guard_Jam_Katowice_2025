using System;
using UnityEngine;

public class StatisticsManager : MonoBehaviour
{
    public static StatisticsManager Instance;

    public event Action OnAnyStatZero;

    [Header("Stats")]
    [Range(0, 100)] public float thirst = 100;  
    [Range(0, 100)] public float hunger = 100;   
    [Range(0, 100)] public float temperature = 100; 
    [Range(0, 100)] public float morale = 100;
    
    [Header("Max Values")]
    public float maxThirst = 100;
    public float maxHunger = 100;
    public float maxTemperature = 100;
    public float maxMorale = 100;
   
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

    private void IsAnyStatZero()
    {
        if (thirst <= 0 || hunger <= 0 || temperature <= 0 || morale <= 0)
        {
            OnAnyStatZero?.Invoke();
        }
    }

    public void ChangeThirst(float amount)
    {
        thirst = Mathf.Clamp(thirst + amount, 0, maxThirst);
        IsAnyStatZero();
    }

    public void ChangeHunger(float amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0, maxHunger);
        IsAnyStatZero();
    }

    public void ChangeTemperature(float amount)
    {
        temperature = Mathf.Clamp(temperature + amount, 0, maxTemperature);
        IsAnyStatZero();
    }

    public void ChangeMorale(float amount)
    {
        morale = Mathf.Clamp(morale + amount, 0, maxMorale);
        IsAnyStatZero();
    }
}