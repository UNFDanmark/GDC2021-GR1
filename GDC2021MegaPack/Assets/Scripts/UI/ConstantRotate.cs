using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstantRotate : MonoBehaviour
{
    private RectTransform myRect;
    public float rotateSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        myRect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        myRect.localEulerAngles = new Vector3(myRect.localEulerAngles.x, myRect.localEulerAngles.y, myRect.localEulerAngles.z + rotateSpeed * Time.deltaTime);
    }
}
