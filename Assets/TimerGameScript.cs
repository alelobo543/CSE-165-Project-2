using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGameScript : MonoBehaviour
{
    public TimerScript timer;
    public bool start;
    float currTime;
    public TMPro.TextMeshPro thisTimer;
    // Start is called before the first frame update
    void Start()
    {
        currTime = 0;
        start=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.start){
            currTime=0;
        }
        if(!timer.start){
            currTime+= Time.deltaTime;
            float timeRemaining = currTime + 1;
            float minutes = Mathf.FloorToInt(timeRemaining / 60);
            float seconds = Mathf.FloorToInt(timeRemaining % 60);
            thisTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
