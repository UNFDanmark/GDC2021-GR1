using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMoveUp : MonoBehaviour
{
    public GameObject[] walls;

    private Transform myTransform;

    bool hasSpawnedExtra = false;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();

        // Moves wall half its height down
        myTransform.position -= new Vector3(0f, myTransform.localScale.y / 2, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn a new wall when at -50 y
        if (myTransform.position.y >= -50 && !hasSpawnedExtra)
        {
            SpawnWalls();
            hasSpawnedExtra = true;
        }
    }

    void SpawnWalls()
    {
        // Gets a random number between 0 and the number of walls
        int wallNum = Random.Range(0, walls.Length);

        // Spawns the next wall
        Instantiate(walls[wallNum], new Vector3(myTransform.position.x, myTransform.position.y - myTransform.localScale.y / 2, myTransform.position.z), myTransform.rotation);
    }
}
