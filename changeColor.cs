using UnityEngine;

public class changeColor : MonoBehaviour
{
    public Color startColor = Color.white;  // Initial color
    public Color endColor = Color.black;      // Target color
    public float duration = 2f;              // Duration of color change (in seconds)

    private float timer = 0f;                // Timer to track progress of color change

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Calculate the progress of color change (0 to 1)
        float progress = Mathf.Clamp01(timer / duration);

        // Interpolate between startColor and endColor based on progress
        Color newColor = Color.Lerp(startColor, endColor, progress);

        // Apply the new color to the object's material
        GetComponent<Renderer>().material.color = newColor;

        // Reset the timer when duration is reached
        if (progress >= 1f)
        {
            timer = 0f;
        }
    }
}

