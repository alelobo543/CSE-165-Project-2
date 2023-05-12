using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideCheck : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    bool hitDetected;
    public TMPro.TextMeshPro text;
    public TimerGameScript stopwatch;
    public TimerScript timer;
    void Start()
    {
        time = 0;
        hitDetected = false;
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(hitDetected == true){
            time += Time.deltaTime;
            if(time < 3){
                text.text = "Checkpoint Reached";
                text.enabled = true;
            }
            else{
                text.text = "";
                time = 0;
                text.enabled = false;
                hitDetected = false;
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("collided");
        if (col.gameObject == GameObject.Find("engineering-campus").GetComponent<Parse>().currcheck)
        {
            Parse parseScript = GameObject.Find("engineering-campus").GetComponent<Parse>();
            if(parseScript.currindex != 0){
                hitDetected = true;
            }
            GameObject.Find("engineering-campus").GetComponent<Parse>().next();
            GameObject.Find("Aircraft").transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            if(parseScript.currindex >= parseScript.checkpoints.Count){
                //race done
                GameObject.Find("Aircraft").transform.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                timer.start = true;
                timer.canMove = false;
            }
        
        }

    }
}
