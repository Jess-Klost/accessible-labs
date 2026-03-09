using UnityEngine;

public class MoveLocation : MonoBehaviour
{
    [Tooltip("Name of the location")]
    public string locationName;
    [Tooltip("The point at which an object moving to this MovementLocation will be placed")]
    public Transform movePoint;
}
