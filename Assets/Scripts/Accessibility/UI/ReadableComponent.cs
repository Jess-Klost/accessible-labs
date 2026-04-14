using UnityEngine.EventSystems;

/// <summary>
/// Reads out label when the UI component is selected.
/// </summary>
public class ReadableComponent : Readable, ISelectHandler
{

    public void OnSelect(BaseEventData eventData)
    {
        SpeakUI(GetFullLabel());
    }
}
