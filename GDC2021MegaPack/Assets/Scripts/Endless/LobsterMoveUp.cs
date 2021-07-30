using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobsterMoveUp : MonoBehaviour
{
    public float minSpeed = 0.25f;
    public float maxSpeed = 0.6f;

    public float moveUpSpeed = 0.5f;

    private Transform myTransform;

    void Awake()
    {
        moveUpSpeed = Random.Range(minSpeed, maxSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moves up at the given speed
        myTransform.position += new Vector3(0, moveUpSpeed * Time.deltaTime, 0);

        // If completely out of view, destroy self
        if (myTransform.position.y >= 10 + myTransform.localScale.y)
        {
            Destroy(gameObject);
        }
    }
}
