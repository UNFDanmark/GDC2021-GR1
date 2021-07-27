using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchCreator : MonoBehaviour
{
    public GameObject archWay;

    public float archChance = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.value < archChance && ScoreHandler.isCompletelyDark)
        {
            archWay.SetActive(true);
        }
    }
}
