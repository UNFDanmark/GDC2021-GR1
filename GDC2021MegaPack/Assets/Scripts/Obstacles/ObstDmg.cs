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

    // Start is called before the first frame update
    void Start()
    {
        // Definerer Rigidbody
        enemyRB = gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Fortæller playerHealth at den skal tage skade
        collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmgAmount);

        // Fortæller rigidbody at vi eksplodere (BOOOOM!)
        collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, gameObject.GetComponent<Transform>().position, explosionRadius);
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}
