using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WebSpeechTest : MonoBehaviour
{
    public TMP_Text inputText;
    public Slider rateSlider;

    public void SpeakCurrentInput()
    {
        UAP_CustomTTS.Speak(inputText.text, rateSlider.value);        
    }
}
