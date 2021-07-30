using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLighting : MonoBehaviour
{
    public Color startColor;
    public Color endColor;

    private Color currentColor;

    private Light sceneLight;

    // Start is called before the first frame update
    void Start()
    {
        sceneLight = GetComponent<Light>();
        currentColor = startColor;
        sceneLight.color = currentColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreHandler.isCompletelyDark) // Bliver kun kaldt når det skal være helt mørkt
        {
            // Laver et tal mellem 0 og 1, til at symbolisere hvor tæt vi er på end value
            float currentProgress = (ScoreHandler.playerScore - ScoreHandler.endDarkValue) / (ScoreHandler.endDarkValue + 20 - ScoreHandler.endDarkValue);

            // Ændrer hver farve lineært i forhold til progress
            currentColor.r = Mathf.Lerp(endColor.r, 0f, currentProgress);
            currentColor.g = Mathf.Lerp(endColor.g, 0f, currentProgress);
            currentColor.b = Mathf.Lerp(endColor.b, 0f, currentProgress);
            currentColor.a = Mathf.Lerp(endColor.a, 0f, currentProgress);

            // Sætter lysets farve til den vi har skabt oven over
            sceneLight.color = currentColor;
        }
        else if (ScoreHandler.hasBegunDarkening) // Bliver kaldt når mørket er begyndt
        {
            // Laver et tal mellem 0 og 1, til at symbolisere hvor tæt vi er på end value
            float currentProgress = (ScoreHandler.playerScore - ScoreHandler.startDarkValue) / (ScoreHandler.endDarkValue - ScoreHandler.startDarkValue);

            // Ændrer hver farve lineært i forhold til progress
            currentColor.r = Mathf.Lerp(startColor.r, endColor.r, currentProgress);
            currentColor.g = Mathf.Lerp(startColor.g, endColor.g, currentProgress);
            currentColor.b = Mathf.Lerp(startColor.b, endColor.b, currentProgress);
            currentColor.a = Mathf.Lerp(startColor.a, endColor.a, currentProgress);

            // Sætter lysets farve til den vi har skabt oven over
            sceneLight.color = currentColor;
        }

    }
}
