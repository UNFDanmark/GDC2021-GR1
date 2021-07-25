using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveUp : MonoBehaviour
{
    public float moveUpSpeed = 0.25f;

    private Transform myTransform;

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
    }
}
