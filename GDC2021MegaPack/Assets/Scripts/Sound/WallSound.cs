using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSound : MonoBehaviour
{
    public AudioSource wall_source;
    bool hit_wall = false;
    public AudioClip Hit, Scrape;

    float time_stamp = -4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (!hit_wall && time_stamp + 2.0f <= Time.time)
            {
                Debug.Log("arh");
                wall_source.clip = Hit;
                wall_source.Play();
                hit_wall = true;
            }
            else if (!wall_source.isPlaying)
            {
                wall_source.clip = Scrape;
                wall_source.Play();

            }
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (wall_source.clip == Scrape)
                wall_source.Stop();
            hit_wall = false;
            time_stamp = Time.time;
        }
    }
}
