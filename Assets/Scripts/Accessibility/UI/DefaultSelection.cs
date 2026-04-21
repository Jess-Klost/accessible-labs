using UnityEngine;
using UnityEngine.UI;

public class DefaultSelection : MonoBehaviour
{
    [Tooltip("UI Component that should be selected by default on scene load")]
    public Selectable defaultSelection;

    void Start()
    {
        defaultSelection.Select();
    }
}
