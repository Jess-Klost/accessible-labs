/// <summary>
/// Reads out the value of a text component when its text value is changed.
/// </summary>
public class ReadableValue : Readable
{
    string currentText;

    void Start()
    {
        currentText = label.text;
    }

    void Update()
    {
        // When the text is changed set currentText and read out new text
        if (label.text != currentText)
        {
            OnTextChange();    
        }
    }

    void OnTextChange()
    {
        currentText = label.text;
        SpeakUI(GetFullLabel());
    }
}
