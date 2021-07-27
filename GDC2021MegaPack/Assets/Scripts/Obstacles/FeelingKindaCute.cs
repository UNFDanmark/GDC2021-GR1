using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelingKindaCute : MonoBehaviour
{
    public Material cuteyMat;

    public GameObject skinHolder;

    // Start is called before the first frame update
    void Start()
    {
        if (Random.value < 0.03f)
        {
            skinHolder.GetComponent<SkinnedMeshRenderer>().material = cuteyMat;
            print("Might delete later, idk ¯|_(ツ)_/¯");
        }
    }
}
