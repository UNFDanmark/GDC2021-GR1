using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    private Rigidbody subRB;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        subRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            subRB.velocity += new Vector3(moveSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            subRB.velocity += new Vector3(-moveSpeed, 0, 0);
        }
    }
}
