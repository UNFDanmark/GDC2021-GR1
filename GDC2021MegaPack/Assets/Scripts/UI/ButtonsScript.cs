using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{

    public void switchToPlayingscene()
    {
        SceneManager.LoadScene("SubmarineScene");

    }
    public void exitGame()
    {
        Application.Quit();
    }

}
