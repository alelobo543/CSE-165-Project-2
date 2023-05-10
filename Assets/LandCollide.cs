using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collided");
        if (col.gameObject == GameObject.Find("Aircraft"))
            
        {
            GameObject airplane = GameObject.Find("Aircraft");
            GameObject.Find("Aircraft").transform.position= GameObject.Find("engineering-campus").GetComponent<Parse>().checkpoints[GameObject.Find("engineering-campus").GetComponent<Parse>().currindex-1].transform.position;
            GameObject.Find("Aircraft").transform.LookAt(GameObject.Find("engineering-campus").GetComponent<Parse>().currcheck.transform);
            GameObject.Find("Aircraft").transform.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            GameObject.Find("Aircraft").transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            Quaternion r = airplane.transform.rotation;
            GameObject.Find("Aircraft").transform.Rotate(-r.eulerAngles.x, 0, -r.eulerAngles.z);

        }

    }
}
