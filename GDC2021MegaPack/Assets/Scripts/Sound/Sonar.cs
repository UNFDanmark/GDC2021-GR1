using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public AudioSource sonar_source;
    public AudioClip sonar;
    public int radius;
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
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(transform.position.x + radius * Mathf.Cos(Time.time), transform.position.y + radius * Mathf.Sin(Time.time), 0)), out hit, Mathf.Infinity, layerMask))
        {
            AudioSource.PlayClipAtPoint(sonar, new Vector3(hit.transform.position.x, hit.transform.position.y, 0)) ;
        }
    }

   

}
