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
        // Finder ud af om vi bev�ger os. Ingen grund til at �ndre rotation hvis vi ikke g�r
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

            // Find vinkel afstand fra nuv�rende vinkel
            zAngleDistance = transform.rotation.eulerAngles.z - targetAngle;

            if (zAngleDistance > 180)
            {
                zAngleDistance -= 360;
            }
            if (zAngleDistance < -180)
            {
                zAngleDistance += 360;
            }

            // Hvis ub�den er t�t nok p� den �nskede vinkel, s�ttes ub�den til vinklen og rotation stoppes
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

            // Flipper ub�den til at passe med x-akse bev�gelse
            if (transform.rotation.eulerAngles.z < 180 && transform.rotation.eulerAngles.z > 0)
            {
                subChildModel.localRotation = Quaternion.Euler(subChildModel.localRotation.eulerAngles.x, 0f, subChildModel.localRotation.eulerAngles.z);
            }
            else if (transform.rotation.eulerAngles.z > 180 || transform.rotation.eulerAngles.z < 0)
            {
                subChildModel.localRotation = Quaternion.Euler(subChildModel.localRotation.eulerAngles.x, 180f, subChildModel.localRotation.eulerAngles.z);
            }
        }
        else
        {
            // Hvis man ikke bev�ger ub�den, skal den ikke �ndre sin rotation
            subRB.angularVelocity = Vector3.zero;
        }
    }
}
