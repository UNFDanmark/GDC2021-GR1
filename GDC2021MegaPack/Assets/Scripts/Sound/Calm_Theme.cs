using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calm_Theme : MonoBehaviour
{
    public AudioClip calm_1, calm_2, calm_3;
    public AudioSource audio;

    private int PrevNum = 0;

    void Start() 
    {
        //Start by playing the pure marimba theme
        audio.Play();
    }

    void FixedUpdate()
    {
        //Only play sound is audio is not currently playing
        if (!audio.isPlaying)
        {
            switch (Get_Random_Number())
            {
                case 1:
                    audio.clip = calm_1;
                    break;
                case 2:
                    audio.clip = calm_2;
                    break;
                case 3:
                    audio.clip = calm_3;
                    break;

            }
            audio.Play();
        }

    }

    //Get a random number from 1-3
    int Get_Random_Number() 
    {
        int ReturnInt;
        ReturnInt = Random.Range(1, 3);

        //Makes sure the number is not the same as last
        if (ReturnInt == PrevNum)
        {
            ReturnInt = Get_Random_Number();
        }
        return ReturnInt;
    }
}
