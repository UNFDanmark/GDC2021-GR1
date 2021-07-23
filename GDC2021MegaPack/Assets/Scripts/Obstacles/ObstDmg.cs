using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstDmg : MonoBehaviour
{
    private Rigidbody enemyRB;

    public int dmgAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Definerer Rigidbody
        enemyRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        // Fortæller playerHealth at den skal tage skade
        collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(dmgAmount);
    }
}
