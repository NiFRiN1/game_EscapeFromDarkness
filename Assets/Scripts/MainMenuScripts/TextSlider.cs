using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSlider : MonoBehaviour
{
    public Slider slider;
    private TextMeshProUGUI text;
    private const string ValueFormat = "F2";

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
  
        slider.onValueChanged.AddListener(OnSliderValueChanged);

        UpdateText(slider.value);
    }

    void OnSliderValueChanged(float value)
    {   
        UpdateText(value);
    }

    void UpdateText(float value)
    {
        text.text = slider.value.ToString(ValueFormat);
    }
}
