using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ReadableComponent : MonoBehaviour, ISelectHandler
{
    public string label;
    public TMP_Text textComponent;

    protected void SpeakUI(string label)
    {
        Debug.Log("TTS: " + label);
        UAP_CustomTTS.Speak(label, 0.7f);
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (textComponent != null)
        {
            SpeakUI(textComponent.text);
        }
        else if (label != "")
        {
            SpeakUI(label);
        }
    }
}
