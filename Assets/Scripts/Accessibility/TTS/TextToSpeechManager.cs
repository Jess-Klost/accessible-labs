using UnityEngine;

/// <summary>
/// Initializes the TTS system. Currently initializes the WebSpeech system.
/// </summary>
public class TextToSpeechManager : MonoBehaviour
{
    void Awake()
    {
        UAP_CustomTTS.InitializeCustomTTS<WebSpeechAPI_TTS>();
    }
}
