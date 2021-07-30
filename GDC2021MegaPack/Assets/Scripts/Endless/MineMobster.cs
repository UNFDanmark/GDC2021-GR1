using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMobster : MonoBehaviour
{
    public GameObject mine;

    private Transform myTrans;

    public LayerMask Walls;

    //Ventetid for hvornår minerne spawner
    public float minWait = 7f;
    public float maxWait = 15f;

    //Koordinater, til spawning af miner
    private float leftXCoordinate = -8.5f;
    private float rightXCoordinate = 8.5f;

    private float waitLength;

    private float currentWait;

    // Bruges til at få minerne til at spawne forskudt fra at vi begynder at gøre skærmen mørkere
    public float spawningDesync = 100f;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = gameObject.GetComponent<Transform>();

        // Chooses a random waiting time
        waitLength = Random.Range(minWait, maxWait);
        // Sets the wait to the chosen waiting time
        currentWait = Time.time + waitLength;
    }

    // Update is called once per frame
    void Update()
    {
        // if wait is over, spawn a mine
        if (Time.time >= currentWait && ScoreHandler.startDarkValue + spawningDesync <= ScoreHandler.playerScore)
        {
            SpawnMines();

            // Chooses a random waiting time
            waitLength = Random.Range(minWait, maxWait);
            // Sets the wait to the chosen waiting time
            currentWait = Time.time + waitLength;
        }
    }

    void SpawnMines()
    {
        if (ScoreHandler.gameGetHarder)
        {
            minWait = 3f;
            maxWait = 6f;
        }
        else if (ScoreHandler.isCompletelyDark)
        {
            minWait = 4f;
            maxWait = 8f;
        }
        // Checker hvorhenne væggene er, så vi kan spawne minerne mellem dem
        float xCoordinate = 0f;

        // Kaster en ray til ventre, som den så får koordinaterne af
        RaycastHit hitLeft;
        Physics.Raycast(transform.position, Vector3.left, out hitLeft, 30f, Walls);
        Vector3 leftWallPosition = hitLeft.point;

        // Kaster en ray til højre, som den så får koordinaterne af
        RaycastHit hitRight;
        Physics.Raycast(transform.position, Vector3.right, out hitRight, 30f, Walls);
        Vector3 rightWallPosition = hitRight.point;

        // Finder ud af om den så en væg eller ej
        if (leftWallPosition != Vector3.zero && rightWallPosition != Vector3.zero)
        {
            // Spawner minen et tilfældigt sted mellem de vægge den så
            xCoordinate = Random.Range(leftWallPosition.x + 1, rightWallPosition.x - 1);
        }
        else
        {
            // Spawner minen et tilfældigt sted mellem manuelt indskreved koordinater
            xCoordinate = Random.Range(leftXCoordinate, rightXCoordinate);
        }


        // Spawns the next mine
        GameObject myMine = Instantiate(mine, new Vector3(xCoordinate, -10, 0), Quaternion.Euler(0, Random.Range(0, 360), 0));
    }
}
