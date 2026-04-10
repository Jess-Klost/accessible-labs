using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

/// <summary>
/// ReadableComponent with dropdown specific functions. Reads out "expanded" 
/// when expanded. Adds the context variable "{items}" which is the amount
/// of items in the dropdown and "{selected}" which is the currently selected
/// item. 
/// </summary>
[RequireComponent(typeof(TMP_Dropdown))]
public class ReadableDropdown : ReadableComponent, ISubmitHandler, ISelectHandler
{
    public TMP_Dropdown dropdown;

    void Awake()
    {
        if (dropdown == null)
            dropdown = GetComponent<TMP_Dropdown>();
    }

    public void OnSubmit(BaseEventData eventData)
    {
        SpeakUI("Expanded");
    }

    protected override string GetFullLabel()
    {
        // Get filled in label from base Readable class and fill in dropdown 
        // specific variables
        return base.GetFullLabel().Replace("{items}",
         dropdown.options.Count.ToString()).Replace("{selected}",
         dropdown.captionText.text);
    }
}
