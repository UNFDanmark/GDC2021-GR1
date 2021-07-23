using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

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

        // If 0 health or below, run death script
        if (currentHealth <= 0)
        {
            Death();
        }
        else if (currentHealth > maxHealth) // If more than max health, set to max health
        {
            currentHealth = maxHealth;
        }
    }

    void Death()
    {
        // Stop time
        Time.timeScale = 0;
        // Destroy submarine
        Destroy(gameObject);
    }
}
