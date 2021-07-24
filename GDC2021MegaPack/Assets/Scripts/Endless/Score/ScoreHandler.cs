using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public static float playerScore = 0f;

    public float pointsPerSecond = 5f;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Resetter playerScore
        playerScore = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Forøger scoren med PointsPerSecond hvert sekund
        playerScore += pointsPerSecond * Time.deltaTime;
        // Skriver en int udgave af playerScore i UI
        scoreText.text = ((int)playerScore).ToString() + " m";
    }
}
