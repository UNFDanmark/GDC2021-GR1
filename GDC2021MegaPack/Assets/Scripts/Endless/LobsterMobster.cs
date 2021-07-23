using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterMobster : MonoBehaviour
{
    public GameObject lobster;

    private Transform myTrans;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

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
