using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor_sound : MonoBehaviour
{

    private Submarine mainSub;
    public AudioSource motor_source;


    // Start is called before the first frame update
    void Start()
    {
        mainSub = transform.parent.parent.gameObject.GetComponent<Submarine>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSub.isMoving && !motor_source.isPlaying)
        {
            motor_source.Play();
        }
        else if(!mainSub.isMoving)
        {
            motor_source.Stop();
        }
    }
}
