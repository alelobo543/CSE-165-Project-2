using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideCheck : MonoBehaviour
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
        if (col.gameObject == GameObject.Find("engineering-campus").GetComponent<Parse>().currcheck)
        {
            GameObject.Find("engineering-campus").GetComponent<Parse>().next();
        }

    }
}
