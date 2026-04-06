using UnityEngine;

public class SpeechRateSlider : MonoBehaviour
{
    public void OnValueChanged(float value)
    {
        Settings.TTSSpeechRate = value;
    }
}
