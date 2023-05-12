using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float rollSpeed = 10f; // Adjust this value to change the roll speed
    public float pitchSpeed = 10f; // Adjust this value to change the pitch speed
    public OVRHand rightHand;
    public OVRHand leftHand;
    private Vector3 startPosition;
    public float rotationSpeed = 2.0f;
    public float maxPitch = 45.0f;
    public float maxRoll = 45.0f;
    float velocity = 1f;
    public TimerScript timer;
    private Quaternion initialRotation;
    private float initialHandRoll;
    void Start()
    {
        initialRotation = transform.rotation;
        initialHandRoll = rightHand.transform.rotation.eulerAngles.z;
        startPosition = rightHand.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {


        if (timer.canMove)
        {
            if(rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) >= 0.72f)
            {
                transform.Rotate(Vector3.right, 85 * Time.deltaTime, Space.Self);
            }

            if (rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Ring) >= 0.72f)
            {
                transform.Rotate(Vector3.right, -85 * Time.deltaTime, Space.Self);
            }
            if (leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) >= 0.72f || Input.GetKey(KeyCode.M))
            {
                transform.Rotate(Vector3.forward, 85 * Time.deltaTime, Space.Self);
            }
            if (leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Ring) >= 0.72f || Input.GetKey(KeyCode.L))
            {
                transform.Rotate(Vector3.forward, -85 * Time.deltaTime, Space.Self);
            }

 
            transform.GetComponent<Rigidbody>().velocity = transform.forward * 25;
        }
    }
}