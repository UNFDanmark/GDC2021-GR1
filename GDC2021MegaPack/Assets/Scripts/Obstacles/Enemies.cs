using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private Rigidbody lobsterRB;
    private Transform lobTrans;

    public float minSpeed = 1f;
    public float maxSpeed = 1.5f;

    private float moveSpeed = 1.25f;

    private bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        lobsterRB = gameObject.GetComponent<Rigidbody>();
        lobTrans = gameObject.GetComponent<Transform>();
        moveSpeed = Random.Range(minSpeed, maxSpeed);


        int moveWay = Random.Range(0, 2);
        moveRight = moveWay == 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (lobTrans.position.x < 10.5f && moveRight)
        {
            moveRight = false;
        }
        else if (lobTrans.position.x > -10.5f && !moveRight)
        {
            moveRight = true;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveRight)
        {
            lobTrans.rotation = Quaternion.Euler(0, 180, 90);
            lobsterRB.velocity = new Vector3(moveSpeed, 0, 0);
        }
        else
        {
            lobTrans.rotation = Quaternion.Euler(0, 0, 90);
            lobsterRB.velocity = new Vector3(-moveSpeed, 0, 0);
        }

        /*
        while (lobTrans.position.x < 10.5f && moveRight)
        {
            lobTrans.rotation = Quaternion.Euler(0, 180, 90);
            lobsterRB.velocity = new Vector3(moveSpeed, 0, 0);
        }

        moveRight = false;

        while (lobTrans.position.x > -10.5f && !moveRight)
        {
            lobTrans.rotation = Quaternion.Euler(0, 0, 90);
            lobsterRB.velocity = new Vector3(-moveSpeed, 0, 0);
        }

        moveRight = true;
        */
    }
}
