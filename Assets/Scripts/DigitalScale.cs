using UnityEngine;
using TMPro;

public class DigitalScale : MonoBehaviour
{
    public TextMeshProUGUI weightDisplayText;
    
    [Header("Detection Settings")]
    [Tooltip("The size of the area above the scale")]
    public Vector3 detectionSize = new Vector3(0f, 0f, 0f);
    
    [Tooltip("Move the detection center on top of the scale model.")]
    public Vector3 detectionOffset = new Vector3(0f, 0f, 0f);

    void Update()
    {
        float totalWeight = 0f;

        // Calculate the center point based on the scale's position + your offset
        Vector3 center = transform.position + detectionOffset;

        // Find colliders inside the box zone. 
        Collider[] hitColliders = Physics.OverlapBox(center, detectionSize / 2, transform.rotation);

        foreach (Collider col in hitColliders)
        {
            // Check if the object has a WeightedItem script
            WeightedItem item = col.GetComponent<WeightedItem>();
            if (item != null)
            {
                totalWeight += item.weight;
            }
        }

        // Display the result
        if (weightDisplayText != null)
        {
            weightDisplayText.text = totalWeight.ToString("F2") + " g";
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position + detectionOffset, detectionSize);
    }
}