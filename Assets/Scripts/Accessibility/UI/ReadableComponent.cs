using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ReadableComponent : Readable, ISelectHandler
{
    public string label;
    public TMP_Text textComponent;

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
