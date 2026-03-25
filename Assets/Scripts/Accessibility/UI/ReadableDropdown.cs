using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_Dropdown))]
public class ReadableDropdown : ReadableComponent, ISubmitHandler, ISelectHandler
{
    public TMP_Dropdown dropdown;
    public string initialLabel;

    void Start()
    {
        if (dropdown == null)
            dropdown = GetComponent<TMP_Dropdown>();
    }

    public new void OnSelect(BaseEventData eventData)
    {
        Debug.Log("OnSelectDrop");
        string foundLabel = "";
        if (textComponent != null)
        {
            foundLabel = textComponent.text;
        }
        else if (label != "")
        {
            foundLabel = label;
        }

        SpeakUI("Collapsed list with " + dropdown.options.Count + " items " + foundLabel);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        SpeakUI("Expanded");
    }
}
