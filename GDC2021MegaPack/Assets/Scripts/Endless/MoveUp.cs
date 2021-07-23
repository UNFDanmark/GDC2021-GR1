using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float moveUpSpeed = 0.25f;

    private Transform myTrans;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moves up at the given speed
        myTrans.position += new Vector3(0, moveUpSpeed * Time.deltaTime, 0);

        // If completely out of view, destroy self
        if (myTrans.position.y >= 10 + myTrans.localScale.y)
        {
            Destroy(gameObject);
        }
    }
}
