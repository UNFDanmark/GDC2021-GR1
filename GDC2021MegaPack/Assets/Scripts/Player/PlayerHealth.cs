using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject[] healthPropellers;

    public float invulnerableLength = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int dmgAmount)
    {
        // Removes the damage amount from health
        currentHealth -= dmgAmount;

        if (dmgAmount > 0)
        {
            StartCoroutine(BecomeInvulnerable());
        }

        // If 0 health or below, run death script
        if (currentHealth <= 0)
        {
            StartCoroutine(Death());
        }
        else if (currentHealth > maxHealth) // If more than max health, set to max health
        {
            currentHealth = maxHealth;
        }

        for (int i = 0; i < dmgAmount; i++)
        {
            healthPropellers[currentHealth + i].SetActive(false);
        }
        // healthText.text = "Health: " + currentHealth.ToString();
    }

    IEnumerator BecomeInvulnerable()
    {
        gameObject.layer = 8;
        yield return new WaitForSeconds(invulnerableLength);
        gameObject.layer = 3;
    }

    public IEnumerator Death()
    {
        // Stopper tiden
        Time.timeScale = 0;

        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("GameOverMenu", LoadSceneMode.Additive);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
