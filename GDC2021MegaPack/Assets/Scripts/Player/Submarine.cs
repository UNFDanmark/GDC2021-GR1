using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    private Rigidbody subRB;

    private Transform subTransform;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        subRB = gameObject.GetComponent<Rigidbody>();
        subTransform = gameObject.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        // Only called if a key is held down
        if (Input.anyKey)
        {
            Move();
        }
    }

    void Move()
    {
        // Oversætter Button Inputs (Fra Input Manager) til bevægelse
        subRB.velocity += new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed, 0);

        // Kig den vej man bevæger sig (højre og venstre)
        if (Input.GetAxis("Horizontal") < 0)
        {
            subTransform.rotation = Quaternion.Euler(0, 180, 90);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            subTransform.rotation = Quaternion.Euler(0, 0, 90);
        }

        /*
        // Gives the player movement in a direction according to input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            subRB.velocity += new Vector3(0, moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            subRB.velocity += new Vector3(0, -moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            subTransform.rotation = Quaternion.Euler(0, 0, 90);
            subRB.velocity += new Vector3(moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            subTransform.rotation = Quaternion.Euler(0, 180, 90);
            subRB.velocity += new Vector3(-moveSpeed, 0, 0);
        }
        */
    }
}
