using UnityEngine;

public class Readable : MonoBehaviour
{
    protected void SpeakUI(string label)
    {
        Debug.Log("TTS: " + label);
        UAP_CustomTTS.Speak(label, Settings.TTSSpeechRate);
    }
}
