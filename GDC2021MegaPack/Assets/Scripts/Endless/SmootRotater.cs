using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmootRotater : MonoBehaviour
{
    public float minSpeed = 0.5f;
    public float maxSpeed = 2f;
    private float rotationSpeed;

    private Transform myTrans;

    void Start()
    {
        rotationSpeed = Random.Range(minSpeed, maxSpeed);

        if (Random.value <= 0.5f)
        {
            rotationSpeed = rotationSpeed * -1f;
        }

        myTrans = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        myTrans.rotation = Quaternion.Euler(0, myTrans.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, 0);
    }
}
