using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.Find("engineering-campus").GetComponent<Parse>().currcheck.transform.position);

    }
}
