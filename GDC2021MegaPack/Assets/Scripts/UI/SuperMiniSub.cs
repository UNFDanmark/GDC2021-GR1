using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperMiniSub : MonoBehaviour
{
    void Start()
    {
        // GetComponent<RectTransform>().anchoredPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        float currentProgress = (ScoreHandler.playerScore - 0f) / (ScoreHandler.endDarkValue - 0f);
        float newYCoordinate = Mathf.Lerp(185f, -193f, currentProgress);

        GetComponent<RectTransform>().localPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, newYCoordinate);
    }
}
