using UnityEngine;

/// <summary>
/// Initializes the TTS system. Currently initializes the WebSpeech system.
/// </summary>
public class TextToSpeechManager : MonoBehaviour
{
    void Start()
    {
        UAP_CustomTTS.InitializeCustomTTS<WebSpeechAPI_TTS>();
    }
}
