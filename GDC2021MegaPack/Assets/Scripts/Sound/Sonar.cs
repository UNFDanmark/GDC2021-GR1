using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public float sonar_speed;
    public AudioClip sonar;
    public float radius;

    // the layer we want to hit, in this case 7, which is enemy
    int layerMask = 1 << 7;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // Raycast object
        RaycastHit hit;

        // The vector for the raycaster
        Vector3 rayVector;

        // Makes the vector spin around
        rayVector = new Vector3(Mathf.Cos(Time.time*sonar_speed), Mathf.Sin(Time.time*sonar_speed), 0);

        if (Physics.Raycast(transform.position, transform.TransformDirection(rayVector), out hit, Mathf.Infinity, layerMask))
        {
            // Is only counted if within radius
            if(hit.distance < radius)
                AudioSource.PlayClipAtPoint(sonar, new Vector3(hit.transform.position.x, hit.transform.position.y, 0), 0.7f) ;
        }
    }

   

}
