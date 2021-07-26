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

    public AudioSource audio;
    public Renderer ChildRend1, ChildRend2, ChildRend3, ChildRend4;


    // Start is called before the first frame update
    void Start()
    {
        // Definerer Rigidbody
        enemyRB = gameObject.GetComponent<Rigidbody>();
 
    }

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

                // Fortæller rigidbody at vi eksplodere (BOOOOM!)
                collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, gameObject.GetComponent<Transform>().position, explosionRadius);
                if (destroyOnHit)
                {
                    audio.Play();
                    ChildRend1.enabled = false;
                    ChildRend2.enabled = false;
                    ChildRend3.enabled = false;
                    ChildRend4.enabled = false;
                    gameObject.GetComponent<Collider>().enabled = false;

                    Destroy(gameObject, audio.clip.length);
                }
            }
        }
    }
}
