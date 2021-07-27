using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarVisual : MonoBehaviour
{
    public float sonar_speed;

    bool over360 = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        // The vector for the raycaster
        Vector3 rayVector;

        // Makes the vector spin around
        rayVector = new Vector3(Mathf.Cos(Time.time * sonar_speed), Mathf.Sin(Time.time * sonar_speed), 0);

        float rayAngle = Vector3.Angle(Vector3.down, rayVector);

        if (over360)
        {
            rayAngle = 360f - rayAngle;
        }

        if (rayAngle > 178f && !over360 && rayAngle < 182f)
        {
            over360 = true;
        }
        else if (rayAngle > 358f)
        {
            over360 = false;
        }

        rayAngle += 90f;

        Debug.Log("ray angle is " + rayAngle);

        transform.Rotate(0f, 0f, rayAngle - transform.rotation.eulerAngles.z, Space.World);
    }
}
