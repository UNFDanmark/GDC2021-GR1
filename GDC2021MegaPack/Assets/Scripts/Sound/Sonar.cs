using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonar : MonoBehaviour
{
    public AudioSource audio;
    private bool Sonar_Has_Gone_Off = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //If the sonar has'nt gone off yet, go off
        //This might be changed later
        if (Sonar_Has_Gone_Off == false && other.tag == "SubCollidor") 
        {
            audio.Play();
            Sonar_Has_Gone_Off = true;
        }
    }
}
