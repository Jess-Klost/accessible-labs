using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Readable slider component. Reads out context when selected and reads value 
/// when changed. Adds the variable "{value}", which is the current value of 
/// the slider. 
/// </summary>
public class ReadableSlider : ReadableComponent
{
    public Slider slider;
    float currentValue;

    void Awake()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
            if (slider == null)
            {
                Debug.LogWarning("No slider found on ReadableSlider");
                return;
            }
        }
        currentValue = slider.value;
        slider.onValueChanged.AddListener(OnValueChanged);
    }

    void OnValueChanged(float value)
    {
        currentValue = value;
        SpeakUI(value.ToString("0.##"));
    }

    protected override string GetFullLabel()
    {
        return base.GetFullLabel().Replace("{value}", currentValue.ToString());
    }
}
