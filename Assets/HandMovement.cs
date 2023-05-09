using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float rollSpeed = 10f; // Adjust this value to change the roll speed
    public float pitchSpeed = 10f; // Adjust this value to change the pitch speed
    public OVRHand rightHand;
    private Vector3 startPosition;
    public float rotationSpeed = 2.0f;
    public float maxPitch = 45.0f;
    public float maxRoll = 45.0f;
    float velocity = 1f;

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

        // apply the hand rotation to the aircraft object
        
        
        /*float pitch = Mathf.Clamp(rightHandRotation.eulerAngles.x, -5f, 5f);
        float roll = Mathf.Clamp(rightHandRotation.eulerAngles.z, -5f, 5f);
        
        transform.rotation = Quaternion.Euler(0f, rightHandRotation.eulerAngles.y, 0f);
        transform.Rotate(pitch, 0f, roll, Space.Self);
        
        Vector3 handLocalPos = GameObject.Find("RightHandAnchor").transform.localPosition; // get the local position of the hand
        Quaternion targetRotation = Quaternion.Euler(-handLocalPos.y, handLocalPos.x, 0f); // calculate the target rotation based on the local position of the hand
        transform.localRotation = targetRotation; // apply the rotation to the aircraft
        */
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index)){
            transform.Rotate(Vector3.right, 30 * Time.deltaTime, Space.Self);
        }
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Middle))
        {
            transform.Rotate(Vector3.right, -30 * Time.deltaTime, Space.Self);
        }
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Ring) || Input.GetKey(KeyCode.M))
        {
            transform.Rotate(Vector3.forward, 30 * Time.deltaTime, Space.Self);
        }
        if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Pinky) || Input.GetKey(KeyCode.L))
        {
            transform.Rotate(Vector3.forward, -30 * Time.deltaTime, Space.Self);
        }

        // set the velocity of the aircraft object
        transform.GetComponent<Rigidbody>().velocity = transform.forward * 10;
    }
}