using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class MoveSelector : MonoBehaviour
{
    public TMP_Dropdown locationDropdown;
    public MovableObject movableObject;

    public void PopulateDropdown(List<MoveLocation> moveLocations)
    {
        List<string> names = new List<string>();
        foreach (MoveLocation location in moveLocations)
        {
            names.Add(location.locationName);
        }
        locationDropdown.ClearOptions();
        locationDropdown.AddOptions(names);
        locationDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    void OnDropdownValueChanged(int index)
    {
        movableObject.MoveTo(index);
    }
}
