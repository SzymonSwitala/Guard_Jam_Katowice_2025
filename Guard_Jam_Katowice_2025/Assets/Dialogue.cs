using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptable Objects/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string text;
    public Choice[] choices;
}

[System.Serializable]
public class Choice
{
    public string optionText;

    public Item[] itemsYouUse;
    public Item[] itemsYouGet;

    [Header("Efekty na statystyki")]
    public int hungerChange;
    public int waterChange;
    public int moraleChange;
    public int temperatureChange;
}