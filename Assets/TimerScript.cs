using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float currTime;
    public bool timerOn = false;
    public bool start;
    public bool canMove = true;
    public TMPro.TextMeshPro timer;
    // Start is called before the first frame update
    void Start()
    {
        currTime = 4;
        timerOn = true;
        canMove= false;
        start=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            timer.enabled = true;
            canMove = false;
            if(currTime > 0)
            {
                currTime -= Time.deltaTime;
                int seconds = Mathf.FloorToInt(currTime % 60);
                if(seconds > 0)
                {
                    timer.text = seconds.ToString();
                }
                else
                {
                    timer.text = "GO!";
                }
            }
            else
            {
                currTime = 0;
                timer.enabled = false;
                timerOn = false;
                start=false;
                canMove = true;
            }
        }
    }

}
