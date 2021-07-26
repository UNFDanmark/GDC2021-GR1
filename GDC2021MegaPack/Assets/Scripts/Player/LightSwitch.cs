using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public float timeEarlierToTurnOn = 100f;

    public GameObject lights;

    // Update is called once per frame
    void Update()
    {
        // timeEarlierToTurnOn f�r komplet m�rke t�ndes der for lysene
        if (ScoreHandler.endDarkValue - timeEarlierToTurnOn <= ScoreHandler.playerScore)
        {
            lights.SetActive(true);
            Destroy(gameObject);
        }
    }
}
