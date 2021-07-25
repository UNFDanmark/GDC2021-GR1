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

    public Transform subChildModel;

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
            Vector2 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            moveDirection = moveDirection.normalized;

            float targetAngle = -Vector2.SignedAngle(moveDirection, Vector2.down);

            // Find vinkel afstand fra nuværende vinkel
            zAngleDistance = transform.rotation.eulerAngles.z - targetAngle;

            if (zAngleDistance > 180)
            {
                zAngleDistance -= 360;
            }
            if (zAngleDistance < -180)
            {
                zAngleDistance += 360;
            }

            // Hvis ubåden er tæt nok på den ønskede vinkel, sættes ubåden til vinklen og rotation stoppes
            if (Mathf.Abs(zAngleDistance) < 10 && Mathf.Abs(zAngleDistance) > -10 && zAngleDistance != 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);
                subRB.angularVelocity = Vector3.zero;
            }
            else if (zAngleDistance != 0)
            {
                // Hvis positiv drejning er korteste afstand, drej den vej
                if (zAngleDistance > 0)
                {
                    subRB.AddTorque(new Vector3(0f, 0f, -1 * rotateSpeed));
                }
                else if (zAngleDistance < 0)
                {
                    subRB.AddTorque(new Vector3(0f, 0f, 1 * rotateSpeed));
                }
            }

            // Flipper ubåden til at passe med x-akse bevægelse
            if (transform.rotation.eulerAngles.z < 180 && transform.rotation.eulerAngles.z > 0)
            {
                subChildModel.localRotation = Quaternion.Euler(subChildModel.localRotation.eulerAngles.x, 0f, subChildModel.localRotation.eulerAngles.z);
            }
            else if (transform.rotation.eulerAngles.z > 180 || transform.rotation.eulerAngles.z < 0)
            {
                subChildModel.localRotation = Quaternion.Euler(subChildModel.localRotation.eulerAngles.x, 180f, subChildModel.localRotation.eulerAngles.z);
            }

            print("Retning fra inputs: " + transform.rotation.eulerAngles.z);

            /*
            // Flipper ubåden til at passe med x-akse bevægelse
            if (moveDirection.x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
            else if (moveDirection.x < 0)
            {
                transform.rotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            }
            */

            /*
            // Skaber en vektor i forhold til inputs og laver det om til en retning
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = moveDirection.normalized;

            // Laver retningen om til en vinkel
            float targetAngle = Vector2.SignedAngle(moveDirection, Vector2.down);

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
            */
        }
        else
        {
            // Hvis man ikke bevæger ubåden, skal den ikke ændre sin rotation
            subRB.angularVelocity = Vector3.zero;
        }
    }
}
