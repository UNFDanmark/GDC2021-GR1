using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void ContinueGame()
    {
        // Fortælle Game Manager at vi godt vil stoppe pause
        StartCoroutine(GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().LoadPauseMenu());
    }
}
