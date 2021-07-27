using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public float sonar_speed;
    public AudioClip sonar;
    public float radius;

    public GameObject sonarSender;

    private GameObject lastHit;

    public float resetLength = 0f;

    // the layer we want to hit, in this case 7, which is enemy
    int layerMask = 1 << 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Giver 1 sekunds cooldown før man kan ramme samme fisk igen
        if (resetLength < 0)
        {
            resetLength -= Time.deltaTime;
        }
        else if (resetLength <= 0 && resetLength > -1f)
        {
            lastHit = null;
            resetLength = -1f;
        }
    }

    private void FixedUpdate()
    {
        // Raycast object
        RaycastHit hit;

        // The vector for the raycaster
        Vector3 rayVector;

        // Makes the vector spin around
        rayVector = new Vector3(Mathf.Cos(Time.time*sonar_speed), Mathf.Sin(Time.time*sonar_speed), 0);
        Debug.DrawRay(transform.position, transform.TransformDirection(rayVector), Color.red, radius);

        if (Physics.Raycast(transform.position, transform.TransformDirection(rayVector), out hit, radius, layerMask))
        {
            bool isTheSameAsLastHit = hit.transform.gameObject == lastHit;
            if (!isTheSameAsLastHit)
            {
                Instantiate(sonarSender, new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z - 1), Quaternion.identity);
                lastHit = hit.transform.gameObject;
                resetLength = 1f;
            }
        }
    }

   

}
