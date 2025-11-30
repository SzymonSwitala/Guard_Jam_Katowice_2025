using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private Transform floatingTextParent;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textField;
    public void SetUpSlider(float value, float maxValue)
    {
        slider.value = value;
        slider.maxValue = maxValue;
    }
    public void UpdateValue(float value)
    {
        slider.value = value;

        textField.text = value + "/" + slider.maxValue;
    }

    public void ShowFloatingText(float amount)
    {
        GameObject go = Instantiate(floatingTextPrefab, floatingTextParent);
        TextMeshProUGUI txt = go.GetComponent<TextMeshProUGUI>();

        txt.text = (amount > 0 ? "+" : "") + amount.ToString();

        if (amount > 0)
            txt.color = Color.green;
        else
            txt.color = Color.red;


        Destroy(go, 1.0f);
    }
}
