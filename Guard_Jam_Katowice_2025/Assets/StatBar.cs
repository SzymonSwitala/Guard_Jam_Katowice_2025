using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatBar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statNameText;
    [SerializeField] private Image fillImage;

    public void Setup(string name)
    {
        statNameText.text = name;
    }

    public void UpdateBar(float value)
    {
        fillImage.fillAmount = value / 100f;
    }
}