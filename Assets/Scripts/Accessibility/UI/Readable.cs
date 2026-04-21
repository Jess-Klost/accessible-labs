using UnityEngine;
using TMPro;

/// <summary>
/// Base class for components that read UI elements 
/// with the TTS system. 
/// </summary>
public class Readable : MonoBehaviour
{
    [Tooltip("Label text for the UI element")]
    public TMP_Text label;
    [Tooltip("Custom text to be read out alongside label, " +
        "if unset label will be read instead. \"{label}\" will be replaced " +
        "with the text in label. See the component's documentation for other" +
        " specific variables.")]
    public string context;

    /// <summary>
    /// Reads out a string using the TTS system.
    /// </summary>
    /// <param name="label">The text to be read by TTS</param>
    protected void SpeakUI(string label)
    {
        Debug.Log("TTS: " + label);
        UAP_CustomTTS.Speak(label, Settings.TTSSpeechRate);
    }

    /// <summary>
    /// <para>Returns a string containing the full label based on the label
    /// and context fields. If context is empty then it returns label.
    /// Else it returns context with any instances of "{label}" replaced
    /// with the text from the label field.</para>
    /// If inheriting this class, override this function to add extra variables
    /// that are specific to the child class. It is recommended to call the base
    /// version of this function within the override to ensure the label variable
    /// is filled in. 
    /// </summary>
    /// <returns>String containing the text from label if context is empty,
    ///  else contains context with all instances of "{label}" replaced with
    ///  the text from label</returns>
    protected virtual string GetFullLabel()
    {
        if (string.IsNullOrEmpty(context))
        {
            return label.text;
        }
        return context.Replace("{label}", label.text);
    }
}
