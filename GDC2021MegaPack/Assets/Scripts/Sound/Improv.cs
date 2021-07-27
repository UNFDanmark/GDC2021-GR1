using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Improv : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource marimba;

    float timeStamp = 0;

    public AudioClip C1, D1, F1, G1, A1, C2, D2, Pause;

    int PrevNum = 3;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        if (Time.time >= timeStamp)
        {
            int caseInt;
            caseInt = Random.Range(0, 4);
            if (caseInt < 4)
            {
                switch (Get_Random_Number(get_range(PrevNum, "-"), get_range(PrevNum, "+")))
                {
                    case 1:
                        marimba.clip = C1;
                        PrevNum = 1;
                        break;
                    case 2:
                        marimba.clip = D1;
                        PrevNum = 2;
                        break;
                    case 3:
                        marimba.clip = F1;
                        PrevNum = 3;
                        break;
                    case 4:
                        marimba.clip = G1;
                        PrevNum = 4;
                        break;
                    case 5:
                        marimba.clip = A1;
                        PrevNum = 5;
                        break;
                    case 6:
                        marimba.clip = C2;
                        PrevNum = 6;
                        break;
                    case 7:
                        marimba.clip = D2;
                        PrevNum = 7;
                        break;
                }
                marimba.Play();
                timeStamp = Time.time + 0.52f;
            }
            else 
            {
                marimba.clip = Pause;
                marimba.Play();
                timeStamp = Time.time + 0.52f;

            }
        }
        

    }

    int Get_Random_Number(int a, int b)
    {
        b++;
        int ReturnInt;
        ReturnInt = Random.Range(a, b);

        //Makes sure the number is not the same as last
        if (ReturnInt == PrevNum)
        {
            ReturnInt = Get_Random_Number(a, b-1);
        }
        return ReturnInt;
    }

    int get_range(int a, string b) 
    {
        if (b == "-")
        {
            if (a <= 2)
                return a;
            else
                return a - 2;

        }
        else 
        {
            if (a >= 6)
                return a;
            else
                return a + 2;
        }
    }

}
