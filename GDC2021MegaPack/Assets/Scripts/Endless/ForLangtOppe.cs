using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLangtOppe : MonoBehaviour
{
    public int dmgAmount = 1000000000;
    public string[] thingsToAttack;

    void OnCollisionEnter(Collision collision)
    {
        // Går gennem hvert tag i "thingsToAttack"
        for (int i = 0; i < thingsToAttack.Length; i++)
        {
            // Tjekker om det den collider med's tag er en af tingene der skal angribes
            if (collision.gameObject.tag == thingsToAttack[i])
            {
                // Fortæller playerHealth at den skal tage skade
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmgAmount);
            }
        }
    }
}
