using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilFishy : MonoBehaviour
{
    public float itsSpeed = 1f;

    public float waitLength = 120f;
    public float waitDistance = 20f;

    private bool hasBegunSpawning = false;

    public GameObject bigFeeeeeshy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBegunSpawning && ScoreHandler.gameGetHarder)
        {
            StartCoroutine(NextSpawnBegin());
            hasBegunSpawning = true;
        }
    }

    public IEnumerator NextSpawnBegin()
    {
        float direction = 1f;

        // Finder en retning
        if (Random.value <= 0.5f)
        {
            direction = -1f;
        }

        // Vælger en højde
        float height = Random.Range(-10f, 10f);

        // Skaber fisken
        GameObject fishy = Instantiate(bigFeeeeeshy, new Vector3(35 * direction, height, 1.1f), Quaternion.identity);

        // Fortæller fisken hvilken vej den skal gå
        fishy.GetComponent<BGFishMove>().moveDirection = - direction;

        // Venter ca. 2 min efter den sidste forsvandt
        float myWait = Random.Range(waitLength - waitDistance, waitLength + waitDistance);

        yield return new WaitForSeconds(70f / itsSpeed + myWait);

        // Restarter sig selv
        StartCoroutine(NextSpawnBegin());
    }
}
