using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ReadableButton : ReadableComponent
{
    public Button button;

    void Start()
    {
        if (button == null)
            button = GetComponent<Button>();
    }
}
