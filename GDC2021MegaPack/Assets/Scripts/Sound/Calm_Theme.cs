 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calm_Theme : MonoBehaviour
{
    public AudioClip calm_1, calm_2, calm_3, overgang, didgerido, deep;
    public AudioSource audio;

    public float originVolume;

    private int PrevNum = 0;

    bool overgang_has_played = false;


    void Start() 
    {
        audio.volume = originVolume;
        //Start by playing the pure marimba theme
        audio.Play();
    }

    void FixedUpdate()
    {
        //Only play sound is audio is not currently playing
        if (!audio.isPlaying && ScoreHandler.playerScore < 185.0f)
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

        //Play overgang
        else if (!audio.isPlaying && !overgang_has_played)
        {
            audio.clip = overgang;
            audio.Play();
            overgang_has_played = true;
        }

        //Spil solo didgerido
        else if (ScoreHandler.playerScore > 300 && ScoreHandler.playerScore < 400 && overgang_has_played) 
        {
             
            audio.volume = 0 + (((ScoreHandler.playerScore - 300.0f) * (6.0f / 10.0f)) / 100.0f);
            if (!audio.isPlaying) 
            {
                audio.clip = didgerido;
                audio.Play();
            }
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
