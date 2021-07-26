using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    private Rigidbody subRB;

    private Transform subTransform;

    public float moveSpeed = 5f;

    public bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        subRB = gameObject.GetComponent<Rigidbody>();
        subTransform = gameObject.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        // Only called if a key is held down
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Move();
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void Move()
    {
        // Oversætter Button Inputs (Fra Input Manager) til bevægelse
        subRB.velocity += new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed, 0);
    }
}
