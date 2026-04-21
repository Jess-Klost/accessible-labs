using System;

public static class Settings
{
    static float _ttsSpeechRate = 1;

    /// <summary>
    /// Rate of speech for the text to speech system.
    /// Must be between 0.1 and 10.  
    /// </summary>
    public static float TTSSpeechRate
    {
        get
        {
            return _ttsSpeechRate;
        }
        set
        {
            // speech rate must be between 0.1 and 10
            _ttsSpeechRate = Math.Clamp(value, 0.1f, 10f);  
        } 
    }
}
