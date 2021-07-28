using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobsterHats : MonoBehaviour
{
    public GameObject hat;

    public float hatChance = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.value < hatChance)
        {
            hat.SetActive(true);
        }
    }
}
