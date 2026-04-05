using UnityEngine;
using TMPro;

public class ReadableValue : Readable
{
    [Tooltip("Text component that will be read when changed")]
    public TMP_Text valueText;
    [Tooltip("Custom text to be read out alongside valueText "
        + "(\"{value}\" will be replaced with the text in valueText).")]
    public string context;

    string currentText;

    void Start()
    {
        if (valueText == null)
        {
            // Attempt to get TMP_Text on game object if unset
            valueText = GetComponent<TMP_Text>();
            if (valueText == null)
                Debug.LogWarning("valueText unset on ReadableValue");
        }
        currentText = valueText.text;
    }

    void Update()
    {
        if (valueText.text != currentText)
        {
            OnTextChange();    
        }
    }

    void OnTextChange()
    {
        currentText = valueText.text;
        SpeakUI(GetLabel());
    }

    string GetLabel()
    {
        if (string.IsNullOrEmpty(context))
        {
            return currentText;
        }
        return context.Replace("{value}", currentText);
    }
}
