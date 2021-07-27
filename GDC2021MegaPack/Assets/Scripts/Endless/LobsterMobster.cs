using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterMobster : MonoBehaviour
{
    public GameObject fish;

    public GameObject ogLobster;

    private Transform myTrans;

    public float startMin = 10f;
    public float startMax = 16f;

    public float endMin = 5f;
    public float endMax = 9f;

    private float minWait;
    private float maxWait;

    private float waitLength;

    private float currentWait;

    // Start is called before the first frame update
    void Start()
    {
        minWait = startMin;
        maxWait = startMax;

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

        if (ScoreHandler.summonTheMobster)
        {
            minWait = 3f;
            maxWait = 6f;
        }        
        else if (ScoreHandler.hasBegunDarkening) // Bliver kaldt når mørket er begyndt
        {
            // Får spawntime til at falde lineært indtil vi rammer komplet mørke
            if (minWait != endMin && maxWait != endMax)
            {
                minWait = Mathf.Lerp(startMin, endMin, (ScoreHandler.playerScore - ScoreHandler.startDarkValue) / (ScoreHandler.endDarkValue - ScoreHandler.startDarkValue));

                maxWait = Mathf.Lerp(startMax, endMax, (ScoreHandler.playerScore - ScoreHandler.startDarkValue) / (ScoreHandler.endDarkValue - ScoreHandler.startDarkValue));
            }
        }

        // Spawns the next lobster

        if (Random.value < 0.01f)
        {
            Instantiate(ogLobster, new Vector3(0, -10, 0), myTrans.rotation);
            print("LOBSTER TIME!");
        }
        else
        {
            Instantiate(fish, new Vector3(0, -10, 0), myTrans.rotation);
        }
    }
}
