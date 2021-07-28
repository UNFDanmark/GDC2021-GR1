using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour
{
    public AudioSource ambient_audioSource;
    
  

    public AudioClip ambient_1, ambient_2, ambient_3, ambient_4;
    int PrevNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Calm_Theme Calm_script = transform.parent.GetComponent<Calm_Theme>();
        if (!ambient_audioSource.isPlaying && Calm_script.didgerido_has_played) 
        {
            StartCoroutine(wait_random_time());
            switch (Get_Random_Number(2, 4))
            {
                case 1:
                    ambient_audioSource.clip = ambient_1;
                    break;
                case 2:
                    ambient_audioSource.clip = ambient_2;
                    break;
                case 3:
                    ambient_audioSource.clip = ambient_3;
                    break;
                case 4:
                    ambient_audioSource.clip = ambient_4;
                    break;

            }
            ambient_audioSource.Play();
        }
        

    }

    IEnumerator wait_random_time() 
    {
        yield return new WaitForSeconds(Random.Range(5, 15));
    }

    int Get_Random_Number(int a, int b)
    {
        int ReturnInt;
        ReturnInt = Random.Range(a, b+1);

        //Makes sure the number is not the same as last
        if (ReturnInt == PrevNum)
        {
            ReturnInt = Get_Random_Number(a, b);
        }
        return ReturnInt;
    }
}
