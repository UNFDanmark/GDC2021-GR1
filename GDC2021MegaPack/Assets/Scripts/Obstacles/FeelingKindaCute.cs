using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingKindaCute : MonoBehaviour
{
    public float cuteChance = 0.03f;

    public Material cuteyMat;

    public GameObject skinHolder;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.value < cuteChance)
        {
            if (skinHolder.GetComponent<SkinnedMeshRenderer>() != null)
            {
                skinHolder.GetComponent<SkinnedMeshRenderer>().material = cuteyMat;
                print("Might delete later, idk ¯|_(ツ)_/¯");
            }
            else
            {
                skinHolder.GetComponent<MeshRenderer>().material = cuteyMat;
            }
        }
    }
}
