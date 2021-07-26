using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBlaster : MonoBehaviour
{
    private Submarine mainSub;

    private ParticleSystem bubbleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        mainSub = transform.parent.gameObject.GetComponent<Submarine>();
        bubbleSpawner = GetComponent<ParticleSystem>();
        bubbleSpawner.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSub.isMoving)
        {
            bubbleSpawner.Play();
        }
        else if (bubbleSpawner.isPlaying)
        {
            bubbleSpawner.Stop();
        }
    }
}
