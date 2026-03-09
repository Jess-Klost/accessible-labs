using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MovableObject : MonoBehaviour
{
    public List<MoveLocation> moveLocations;
    public MoveLocation initialLocation;
    public MoveSelector moveSelector;

    void Start()
    {
        moveSelector.PopulateDropdown(moveLocations);
    }

    public void MoveTo(int index)
    {
        gameObject.transform.SetPositionAndRotation(moveLocations[index].movePoint.position, gameObject.transform.rotation);
    }
}
