using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private Transform floatingTextParent;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI textField;

    public void SetUpSlider(int value, int maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = value;
        textField.text = value + "/" + maxValue;
    }

    public void UpdateValue(int value)
    {
        int diff = value - (int)slider.value;

        ShowFloatingText(diff);

        slider.value = value;
        textField.text = value + "/" + (int)slider.maxValue;
    }

    public void ShowFloatingText(int amount)
    {
        if (amount == 0) return;

        int count = floatingTextParent.childCount;
        float offset = count * 25f;

        GameObject go = Instantiate(floatingTextPrefab, floatingTextParent);
        RectTransform rt = go.GetComponent<RectTransform>();
        rt.anchoredPosition += new Vector2(offset, offset);

        TextMeshProUGUI txt = go.GetComponentInChildren<TextMeshProUGUI>();

        txt.text = (amount > 0 ? "+" : "") + amount;
        txt.color = amount > 0 ? Color.green : Color.red;

        Destroy(go, 3f);
    }
}