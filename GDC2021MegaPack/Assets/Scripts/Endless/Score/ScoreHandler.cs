using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    public static float playerScore = 0f;

    public float pointsPerSecond = 5f;

    public float beginDarkening = 100f;
    public static bool hasBegunDarkening = false;

    public float completeDarkness = 500f;
    public static bool isCompletelyDark = false;

    public float extraDifficulty = 1000f;
    public static bool gameGetHarder = false;

    public float lobsterDifficulty = 2000f;
    public static bool summonTheMobster = false;

    public static float startDarkValue;
    public static float endDarkValue;

    public TMP_Text scoreTextPro;

    // Start is called before the first frame update
    void Awake()
    {
        startDarkValue = beginDarkening;
        endDarkValue = completeDarkness;
        extraDifficulty = 2 * completeDarkness;
        lobsterDifficulty = 2 * extraDifficulty;

        // Resetter playerScore
        playerScore = 0f;

        // Resetter variabler i forhold til nye score
        hasBegunDarkening = playerScore >= beginDarkening;
        isCompletelyDark = playerScore >= completeDarkness;
        gameGetHarder = playerScore >= extraDifficulty;
    }

    // Update is called once per frame
    void Update()
    {
        // Forøger scoren med PointsPerSecond hvert sekund
        playerScore += pointsPerSecond * Time.deltaTime;
        // Skriver en int udgave af playerScore i UI
        scoreTextPro.text = ((int)playerScore).ToString() + " m";

        hasBegunDarkening = playerScore >= beginDarkening;
        isCompletelyDark = playerScore >= completeDarkness;
        gameGetHarder = playerScore >= extraDifficulty;
    }
}
