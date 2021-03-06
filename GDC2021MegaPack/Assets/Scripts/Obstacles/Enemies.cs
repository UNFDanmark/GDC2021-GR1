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

    public float sizeVariance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the rigidbody and transform components
        lobsterRB = gameObject.GetComponent<Rigidbody>();
        lobTrans = gameObject.GetComponent<Transform>();

        // Giver lobsters tilf?ldig st?rrelse n?r de spawner
        float newSize = Random.Range(1f - sizeVariance, 1f + sizeVariance);
        transform.localScale = new Vector3(newSize, newSize, newSize);

        // Increaser min-speed n?r spillet er sv?rere
        if (ScoreHandler.gameGetHarder)
        {
            minSpeed += 1f;
            maxSpeed += 1f;
        }

        // Sets a random movement speed between min and max
        moveSpeed = Random.Range(minSpeed, maxSpeed);

        // Chooses a random way to go
        int moveWay = Random.Range(0, 2);
        moveRight = moveWay == 1;
    }

    void FixedUpdate()
    {
        // Laver en retningsvektor mod h?jre
        Vector3 laserDirection = Vector3.right;

        // Hvis lobster bev?ger sig mod venstre, drejes retningsvektoren ogs? den vej
        if (!moveRight)
        {
            laserDirection = laserDirection * -1;
        }

        // Tegner lobster's syn i editor
        // Debug.DrawRay(laserSpawn.position, laserDirection, Color.green, seeForwardDistance);

        // Skyder en laser fra dens angivne spawnPoint (Tom transform sat foran lobsteren), i retningen lobsteren bev?ger sig, s? langt frem den kan se og kun p? v?gge
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
            lobTrans.rotation = Quaternion.Euler(0, 180, transform.localRotation.eulerAngles.z);
            // Makes lobster move right
            lobsterRB.velocity = new Vector3(moveSpeed, 0, 0);
        }
        else
        {
            // Same as above, just left
            lobTrans.rotation = Quaternion.Euler(0, 0, transform.localRotation.eulerAngles.z);
            lobsterRB.velocity = new Vector3(-moveSpeed, 0, 0);
        }
    }
}
