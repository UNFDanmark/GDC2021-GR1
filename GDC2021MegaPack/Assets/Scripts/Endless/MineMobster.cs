using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMobster : MonoBehaviour
{
    public GameObject mine;

    private Transform myTrans;

    public float minWait = 7f;
    public float maxWait = 15f;

    private float leftXCoordinate = -8.5f;
    private float rightXCoordinate = 8.5f;

    private float speedOfMines = 0.5f;

    private float waitLength;

    private float currentWait;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = gameObject.GetComponent<Transform>();
        SpawnMines();

        // Chooses a random waiting time
        waitLength = Random.Range(minWait, maxWait);
        // Sets the wait to the chosen waiting time
        currentWait = Time.time + waitLength;
    }

    // Update is called once per frame
    void Update()
    {
        // if wait is over, spawn a mine
        if (Time.time >= currentWait)
        {
            SpawnMines();

            // Chooses a random waiting time
            waitLength = Random.Range(minWait, maxWait) / speedOfMines;
            // Sets the wait to the chosen waiting time
            currentWait = Time.time + waitLength;
        }
    }

    void SpawnMines()
    {
        /*
        // Gets a random number between 0 and the number of walls
        int wallNum = Random.Range(0, walls.Length);
        */
        float xCoordinate = Random.Range(leftXCoordinate, rightXCoordinate);

        // Spawns the next mine
        GameObject myMine = Instantiate(mine, new Vector3(xCoordinate, -10, 0), Quaternion.Euler(0, Random.Range(0, 360), 0));

        // Finder ud af hvor hurtig den sidste mine var
        speedOfMines = myMine.GetComponent<LobsterMoveUp>().moveUpSpeed;

    }
}
