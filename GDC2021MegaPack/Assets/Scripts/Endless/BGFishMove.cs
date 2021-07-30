using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGFishMove : MonoBehaviour
{
    public float moveDirection = 1f;
    private bool hasFlipped = false;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.right * moveDirection * Time.deltaTime;

        if (moveDirection == -1 && !hasFlipped)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            hasFlipped = true;
        }
    }
}
