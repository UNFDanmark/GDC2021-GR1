using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMobster : MonoBehaviour
{
    public float minWait = 60f;
    public float maxWait = 70f;

    private float waitLength;

    public GameObject greenOrb;

    public LayerMask Walls;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnOrb());
    }

    IEnumerator SpawnOrb()
    {
        // Waits a random amount (sus) of time between min and max
        waitLength = Random.Range(minWait, maxWait);
        yield return new WaitForSeconds(waitLength);

        // Following is copy-pasted wall checking from mine-spawning script
        // Checker hvorhenne v�ggene er, s� vi kan spawne minerne mellem dem
        float xCoordinate = 0f;

        // Kaster en ray til ventre, som den s� f�r koordinaterne af
        RaycastHit hitLeft;
        Physics.Raycast(transform.position, Vector3.left, out hitLeft, 30f, Walls);
        Vector3 leftWallPosition = hitLeft.point;

        // Kaster en ray til h�jre, som den s� f�r koordinaterne af
        RaycastHit hitRight;
        Physics.Raycast(transform.position, Vector3.right, out hitRight, 30f, Walls);
        Vector3 rightWallPosition = hitRight.point;

        // Finder ud af om den s� en v�g eller ej
        if (leftWallPosition != Vector3.zero && rightWallPosition != Vector3.zero)
        {
            // Spawner minen et tilf�ldigt sted mellem de v�gge den s�
            xCoordinate = Random.Range(leftWallPosition.x + 1, rightWallPosition.x - 1);
        }
        else
        {
            // Spawner minen et tilf�ldigt sted mellem manuelt indskreved koordinater
            xCoordinate = Random.Range(-3f, 3f);
        }


        // Spawns the next green orb
        Instantiate(greenOrb, new Vector3(xCoordinate, -10, 0), Quaternion.identity);

        // Restarts the coroutine
        StartCoroutine(SpawnOrb());
    }
}
