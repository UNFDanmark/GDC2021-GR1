using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrbScript : MonoBehaviour
{
    private Rigidbody ballRB;

    public string thingsToBoost = "Player";

    public AudioSource dam_audio;

    public Transform laserSpawn;

    private float moveSpeed = 1.5f;

    public float seeForwardDistance = 0.5f;

    public LayerMask onlyWalls;

    private bool moveRight = true;


    // Start is called before the first frame update
    void Start()
    {
        // Definerer Rigidbody
        ballRB = gameObject.GetComponent<Rigidbody>();

        // Chooses a random way to go
        int moveWay = Random.Range(0, 2);
        moveRight = moveWay == 1;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Tjekker om det den collider med's tag er en player
        if (collision.gameObject.tag == thingsToBoost)
        {
            // Forteller scoreTracker at scoren skal increase hurtigere
            GameObject.FindGameObjectWithTag("ScoreTracker").GetComponent<ScoreHandler>().pointsPerSecond += 0.5f;

            // Disables children and plays SFX
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);

            dam_audio.Play();

            //Destroy when audioclip is done
            Destroy(gameObject, dam_audio.clip.length);
        }
    }

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
            // Makes lobster move right
            ballRB.velocity = new Vector3(moveSpeed, 0, 0);
        }
        else
        {
            // Same as above, just left
            ballRB.velocity = new Vector3(-moveSpeed, 0, 0);
        }
    }
}
