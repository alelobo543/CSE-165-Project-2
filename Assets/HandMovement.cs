using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rightHandRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        float pitch = Mathf.Clamp(rightHandRotation.eulerAngles.x, -90f, 90f);

        float roll = Mathf.Clamp(rightHandRotation.eulerAngles.z, -90f, 90f);

        // apply the pitch and roll to the plane object
        transform.rotation = Quaternion.Euler(pitch * 1.1f * Time.deltaTime, transform.rotation.y, roll * 1.1f * Time.deltaTime);
        transform.GetComponent<Rigidbody>().velocity = transform.forward * 2;
    }
}
