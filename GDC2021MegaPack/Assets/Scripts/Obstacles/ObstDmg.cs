using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstDmg : MonoBehaviour
{
    private Rigidbody enemyRB;

    public int dmgAmount = 1;

    public float explosionPower = 30f;
    public float explosionRadius = 1.5f;

    public bool destroyOnHit = false;

    public string[] thingsToAttack;

    public AudioSource dam_audio;


    // Start is called before the first frame update
    void Start()
    {
        // Definerer Rigidbody
        enemyRB = gameObject.GetComponent<Rigidbody>();
 
    }

    void OnCollisionEnter(Collision collision)
    {
        // G�r gennem hvert tag i "thingsToAttack"
        for (int i = 0; i < thingsToAttack.Length; i++)
        {
            // Tjekker om det den collider med's tag er en af tingene der skal angribes
            if (collision.gameObject.tag == thingsToAttack[i])
            {
                // Fort�ller playerHealth at den skal tage skade
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmgAmount);

                // Fort�ller rigidbody at vi eksploderer (BOOOOM!)
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
