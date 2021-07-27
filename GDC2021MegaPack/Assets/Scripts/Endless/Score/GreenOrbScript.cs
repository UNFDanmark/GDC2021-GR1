using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrbScript : MonoBehaviour
{
    private Rigidbody ballRB;

    public int dmgAmount = 1;

    public float explosionPower = 30f;
    public float explosionRadius = 1.5f;

    public bool destroyOnHit = false;

    public string[] thingsToBoost;

    public AudioSource dam_audio;


    // Start is called before the first frame update
    void Start()
    {
        // Definerer Rigidbody
        ballRB = gameObject.GetComponent<Rigidbody>();

    }

    void OnCollisionEnter(Collision collision)
    {
        // Gor gennem hvert tag i "thingsToAttack"
        for (int i = 0; i < thingsToBoost.Length; i++)
        {
            // Tjekker om det den collider med's tag er en af tingene der skal angribes
            if (collision.gameObject.tag == thingsToBoost[i])
            {
                // Forteller playerHealth at den skal tage skade
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmgAmount);

                // Forteller rigidbody at vi eksplodere (BOOOOM!)
                collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, gameObject.GetComponent<Transform>().position, explosionRadius);
                if (destroyOnHit)
                {


                    foreach (Transform child in transform)
                        child.gameObject.SetActive(false);

                    dam_audio.Play();

                    //Destroy when audioclip is done
                    Destroy(gameObject, dam_audio.clip.length);
                }
            }
        }
    }
}
