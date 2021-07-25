using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Rigidbody lobsterRB;
    private Transform lobTrans;

    public Transform laserSpawn;

    public float minSpeed = 1f;
    public float maxSpeed = 1.5f;

    private float moveSpeed = 1.25f;

    public float seeForwardDistance = 0.5f;

    public LayerMask onlyWalls;

    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the rigidbody and transform components
        lobsterRB = gameObject.GetComponent<Rigidbody>();
        lobTrans = gameObject.GetComponent<Transform>();

        // Sets a random movement speed between min and max
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        // Chooses a random way to go
        int moveWay = Random.Range(0, 2);
        moveRight = moveWay == 1;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (lobTrans.position.x > 8.5f && moveRight)
        {
            moveRight = false;
        } // Opposite of above
        else if (lobTrans.position.x < -8.5f && !moveRight)
        {
            moveRight = true;
        }
        */
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Laver en retningsvektor mod højre
        Vector3 laserDirection = Vector3.right;

        // Hvis lobster bevæger sig mod venstre, drejes retningsvektoren også den vej
        if (!moveRight)
        {
            laserDirection = laserDirection * -1;
        }

        // Tegner lobster's syn i editor
        // Debug.DrawRay(laserSpawn.position, laserDirection, Color.green, seeForwardDistance);

        // Skyder en laser fra dens angivne spawnPoint (Tom transform sat foran lobsteren), i retningen lobsteren bevæger sig, så langt frem den kan se og kun på vægge
        if (Physics.Raycast(laserSpawn.position, laserDirection, seeForwardDistance, onlyWalls) && moveRight)
        {
            moveRight = false;
        }// Opposite of above
        else if (Physics.Raycast(laserSpawn.position, laserDirection, seeForwardDistance, onlyWalls) && !moveRight)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            // Sets rotation to make lobster look right
            lobTrans.rotation = Quaternion.Euler(0, 180, 90);
            // Makes lobster move right
            lobsterRB.velocity = new Vector3(moveSpeed, 0, 0);
        }
        else
        {
            // Same as above, just left
            lobTrans.rotation = Quaternion.Euler(0, 0, 90);
            lobsterRB.velocity = new Vector3(-moveSpeed, 0, 0);
        }
    }
}
