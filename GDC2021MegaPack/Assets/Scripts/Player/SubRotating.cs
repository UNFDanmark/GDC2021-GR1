using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubRotating : MonoBehaviour
{
    private Rigidbody subRB;

    public float rotateSpeed = 5f;

    private bool isMoving = false;

    float zAngleDistance;

    float rotationDirection;

    // Start is called before the first frame update
    void Start()
    {
        subRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Finder ud af om vi bevæger os. Ingen grund til at ændre rotation hvis vi ikke gør
        isMoving = GetComponent<Submarine>().isMoving;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Skaber en vektor i forhold til inputs og laver det om til en retning
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = moveDirection.normalized;

            // Laver retningen om til en vinkel
            float targetAngle = Vector2.Angle(moveDirection, Vector2.down);

            if (moveDirection.x < 0)
            {
                targetAngle = -targetAngle;
            }


            zAngleDistance = transform.rotation.eulerAngles.z - targetAngle;

            print("target is :" + targetAngle + " and distance from current rotation is: " + zAngleDistance);

            // Find ud af hvilken vej er kortest mod targetAngle
            if (zAngleDistance > 180 || zAngleDistance < 0)
            {
                rotationDirection = -1;
            }
            else
            {
                rotationDirection = 1;
            }

            if (zAngleDistance <= 1 && zAngleDistance != 0)
            {
                zAngleDistance = 0;
                subRB.angularVelocity = Vector3.zero;
            }
            else if (zAngleDistance != 0)
            {
                // Tilføj torque i den retning
                subRB.AddTorque(new Vector3(0f, 0f, zAngleDistance * rotateSpeed * rotationDirection));
                subRB.angularVelocity = Vector3.zero;
            }
            subRB.angularVelocity = Vector3.zero;
        }        
    }
}
