using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class MoveSelector : MonoBehaviour
{
    public Button moveButton;
    public TMP_Dropdown locationDropdown;
    public MovableObject movableObject;

    /// <summary>
    /// Keeps track of the current event that is called when moveButton is pressed 
    /// to move movableObject. This allows the old listener to be removed without
    /// removing other listeners. 
    /// </summary>
    private UnityEngine.Events.UnityAction currentEvent = null;

    public void PopulateDropdown(List<MoveLocation> moveLocations)
    {
        List<string> names = new List<string>();
        foreach (MoveLocation location in moveLocations)
        {
            names.Add(location.locationName);
        }
        locationDropdown.ClearOptions();
        locationDropdown.AddOptions(names);
        currentEvent = () => movableObject.MoveTo(0);
        moveButton.onClick.AddListener(currentEvent);
        locationDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    void OnDropdownValueChanged(int index)
    {
        moveButton.onClick.RemoveListener(currentEvent);
        currentEvent = () => movableObject.MoveTo(index);
        moveButton.onClick.AddListener(currentEvent);
    }
}
