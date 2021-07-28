using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerScript : MonoBehaviour
{
    public Submarine subScript;

    public float rotateSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (subScript.isMoving)
        {
            transform.Rotate(new Vector3(0f, rotateSpeed, 0f));
        }
    }
}
