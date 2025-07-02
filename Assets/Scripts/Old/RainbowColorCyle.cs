using UnityEngine;

/// <summary>
/// Continuously cycles the object's color through the rainbow using HSV color space.
/// </summary>
[RequireComponent(typeof(Renderer))]
public class RainbowColorCycle : MonoBehaviour
{
    [Header("Color Settings")]
    [SerializeField] private float speed = 1f;

    private Material material;
    private float hue;

    private void Awake()
    {
        // Cache material reference
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // Advance hue based on speed
        hue += Time.deltaTime * speed;
        if (hue > 1f)
        {
            hue -= 1f;
        }

        // Convert hue to RGB and apply it
        Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f);
        material.color = rainbowColor;
    }
}