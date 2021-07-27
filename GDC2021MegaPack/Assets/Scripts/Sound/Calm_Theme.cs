 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calm_Theme : MonoBehaviour
{
    public AudioClip calm_1, calm_2, calm_3, overgang, didgerido, deep;
    public AudioSource audio;

    public float originVolume = 0.05f;

    private int PrevNum = 0;

    bool overgang_has_played = false;
    bool didgerido_has_played = false;

    public bool play_Deep_theme = false;


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
            switch (Get_Random_Number(1, 3))
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
            PrevNum = 0;
            audio.clip = overgang;
            audio.Play();
            overgang_has_played = true;
        }

        //Spil solo didgerido
        else if (ScoreHandler.playerScore > 300 && overgang_has_played && ScoreHandler.playerScore < 300+didgerido.length)
        {
            audio.volume = 0 + (((ScoreHandler.playerScore - 300.0f) * (3.6f / 10.0f)) / 100.0f);
            if (!audio.isPlaying)
            {
                audio.clip = didgerido;
                audio.Play();

                play_Deep_theme = true;
            }
        }

        else if (play_Deep_theme && !audio.isPlaying)
        {
            audio.volume = 0.15f;
            audio.clip = deep;
            audio.Play();
        }

    }


    //Get a random number from 1-3
    int Get_Random_Number(int a, int b) 
    {
        int ReturnInt;
        ReturnInt = Random.Range(a, b);

        //Makes sure the number is not the same as last
        if (ReturnInt == PrevNum)
        {
            ReturnInt = Get_Random_Number(a,b);
        }
        return ReturnInt;
    }
}
