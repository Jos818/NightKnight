using UnityEngine;
using TMPro;
using System.Collections;

public class DeathText : MonoBehaviour
{
    public float startScale = 0.1f;          // Starting scale for the text
    public float endScale = 1f;              // Ending scale for the text
    [SerializeField] private float duration;

    private TextMeshProUGUI deathText;       // Reference to the TextMeshProUGUI component
    private float elapsedTime = 0f;          // Time elapsed since the text started growing
    private Color startColor;                // Starting color for the text

    void Start()
    {
        // Get a reference to the TextMeshProUGUI component
        deathText = GetComponent<TextMeshProUGUI>();

        deathText.enabled = true;

        // Set the initial scale and color of the text
        deathText.transform.localScale = new Vector3(startScale, startScale, startScale);
        startColor = deathText.color;
        deathText.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
    }

    public void StartGrowingText()
    {
        // Reset the elapsed time
        elapsedTime = 0f;

        // Start the growing process
        StartCoroutine(GrowText());
    }

    private IEnumerator GrowText()
    {
        // Loop until the text has finished growing and fading in
        while (elapsedTime < duration)
        {
            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the current scale based on the elapsed time
            float currentScale = Mathf.Lerp(startScale, endScale, elapsedTime / duration);

            // Set the scale of the text
            deathText.transform.localScale = new Vector3(currentScale, currentScale, currentScale);

            // If the text has finished growing
            if (elapsedTime >= duration)
            {
                // Set the color of the text to fully opaque
                deathText.color = startColor;
            }
            else
            {
                // Calculate the current alpha value based on the elapsed time
                float currentAlpha = Mathf.Lerp(0f, startColor.a, elapsedTime / duration);

                // Set the alpha value of the text
                deathText.color = new Color(startColor.r, startColor.g, startColor.b, currentAlpha);
            }

            yield return null;
        }
    }
}
