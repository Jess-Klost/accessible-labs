/// <summary>
/// Exposes a function to read out the label text. Typically used to allow a
/// button to read out a text component (use button's UnityEvent to call).
/// </summary>
public class ReadableText : Readable
{
    public void ReadText()
    {
        SpeakUI(GetFullLabel());
    }
}
