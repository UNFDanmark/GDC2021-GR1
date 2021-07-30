using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperMiniSub : MonoBehaviour
{
    private RectTransform myRect;

    public float rotateSpeed = 1f;

    public float rotateDegrees = 5f;

    private float turnDirection = 1f;

    void Start()
    {
        myRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Får et tal med hvor langt nede UI ubåden skal være på måleren
        float currentProgress = (ScoreHandler.playerScore - 0f) / (ScoreHandler.endDarkValue - 0f);
        float newYCoordinate = Mathf.Lerp(185f, -193f, currentProgress);

        // Rykker UI ubåden ned
        myRect.localPosition = new Vector2(myRect.anchoredPosition.x, newYCoordinate);

        // Ændrer retning når den når rotateDegrees vinkel
        if (myRect.localEulerAngles.z >= rotateDegrees && myRect.localEulerAngles.z < 180)
        {
            turnDirection = -1f;
        }
        else if (myRect.localEulerAngles.z <= 360 - rotateDegrees && myRect.localEulerAngles.z > 180)
        {
            turnDirection = 1f;
        }

        // Roterer UI ubåden
        myRect.localEulerAngles = new Vector3(myRect.localEulerAngles.x, myRect.localEulerAngles.y, myRect.localEulerAngles.z + rotateSpeed * Time.deltaTime * turnDirection);
    }
}
