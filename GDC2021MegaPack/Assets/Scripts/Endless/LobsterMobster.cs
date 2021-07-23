using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterMobster : MonoBehaviour
{
    public GameObject lobster;

    private Transform myTrans;

    public float minWait = 14f;
    public float maxWait = 20f;
    private float waitLength;

    private float currentWait;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = gameObject.GetComponent<Transform>();
        SpawnLobsters();

        // Chooses a random waiting time
        waitLength = Random.Range(minWait, maxWait);
        // Sets the wait to the chosen waiting time
        currentWait = Time.time + waitLength;
    }

    // Update is called once per frame
    void Update()
    {
        // if wait is over, spawn a lobster
        if (Time.time >= currentWait)
        {
            SpawnLobsters();

            // Chooses a random waiting time
            waitLength = Random.Range(minWait, maxWait);
            // Sets the wait to the chosen waiting time
            currentWait = Time.time + waitLength;
        }
    }

    void SpawnLobsters()
    {
        /*
        // Gets a random number between 0 and the number of walls
        int wallNum = Random.Range(0, walls.Length);
        */

        // Spawns the next wall
        Instantiate(lobster, new Vector3(0, -10, 0), myTrans.rotation);

        // i må godt slette wall spawner :D
    }
}
