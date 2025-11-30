using TMPro;
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
        ShowFloatingText(value - slider.value);

        slider.value = value;

        textField.text = value + "/" + slider.maxValue;
     
    }

    public void ShowFloatingText(float amount)
    {
        if (amount == 0) return;

       
        int count = floatingTextParent.childCount;
        float offset = count * 25f;

        GameObject go = Instantiate(floatingTextPrefab, floatingTextParent);

        RectTransform rt = go.GetComponent<RectTransform>();
        rt.anchoredPosition += new Vector2(offset, -offset);

        TextMeshProUGUI txt = go.GetComponentInChildren<TextMeshProUGUI>();
 
        int rounded = Mathf.RoundToInt(amount);
        txt.text = (rounded > 0 ? "+" : "") + rounded;
        txt.color = rounded > 0 ? Color.green : Color.red;

        Destroy(go, 3.0f);
    }
}
