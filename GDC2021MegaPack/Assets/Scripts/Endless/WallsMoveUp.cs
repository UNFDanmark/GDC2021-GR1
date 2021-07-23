using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMoveUp : MonoBehaviour
{
    public GameObject[] walls;

    private Transform myTrans;

    bool hasSpawnedExtra = false;


    // Start is called before the first frame update
    void Start()
    {
        myTrans = gameObject.GetComponent<Transform>();

        // Moves wall half its height down
        myTrans.position -= new Vector3(0, myTrans.localScale.y / 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn a new wall when at -50 y
        if (myTrans.position.y >= -50 && !hasSpawnedExtra)
        {
            SpawnWalls();
            hasSpawnedExtra = true;
        }

        // If completely out of view, destroy self
        if (myTrans.position.y >= 10 + myTrans.localScale.y)
        {
            Destroy(gameObject);
        }
    }

    void SpawnWalls()
    {
        // Gets a random number between 0 and the number of walls
        int wallNum = Random.Range(0, walls.Length);

        // Spawns the next wall
        Instantiate(walls[wallNum], new Vector3(0, myTrans.position.y - myTrans.localScale.y / 2, 0), myTrans.rotation);

        // i må godt slette wall spawner :D
    }
}
