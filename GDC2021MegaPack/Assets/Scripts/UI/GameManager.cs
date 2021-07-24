using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool pauseIsOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            StartCoroutine(LoadPauseMenu());
        }
    }

    IEnumerator LoadPauseMenu()
    {
        // Hvis pause menu ikke er åben, begynder øverste del at køre
        if (!pauseIsOpen)
        {
            // Stopper tiden
            Time.timeScale = 0;

            // The Application loads the Scene in the background as the current Scene runs.
            // This is particularly good for creating loading screens.
            // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
            // a sceneBuildIndex of 1 as shown in Build Settings.

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
            // Siger at menuen er åben
            pauseIsOpen = true;
        }
        else // Hvis pause menuen var åben da der blev trykket "pause", kører denne del
        {
            // Starter tiden
            Time.timeScale = 1;
            // Lukker pausemenu-scenen
            SceneManager.UnloadSceneAsync("PauseMenu");
            // Siger at menuen er lukket
            pauseIsOpen = false;
        }
    }
}
