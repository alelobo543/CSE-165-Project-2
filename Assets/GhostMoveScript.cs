using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GhostMoveScript : MonoBehaviour
{
    int ticks = 90;
    float t;
    
    public List<string> currentBest = new List<string>();
    public GameObject aircraft;
    public GameObject Ghost;
    string curFile;
    bool done;
    bool some;
    bool exist;
    int ind =0;
    public TimerScript timer;
    public TMPro.TextMeshPro Timer;
    public TMPro.TextMeshPro BestTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        done=false;
        some=false;
        t=0;
        curFile="C:/Users/alobo/Downloads/Best.txt";
        if(File.Exists(curFile)){
            exist=true;
            using (StreamReader sr = new StreamReader(curFile))
            {
                while (sr.Peek() >= 0)
                {
                    currentBest.Add(sr.ReadLine());
                    
                }
            }
            BestTimer.text="Best Time:"+ currentBest[currentBest.Count-1];
        }
        else{
            
            exist=false;
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        float dur = 1f/ticks;
        t+=Time.deltaTime;
        
            while(t>=dur){
                t-=dur;
                
                if(true&&ind<currentBest.Count-2){
                    string[] both = currentBest[ind].Split(';');
                    string[] posi = both[0].Split(",");
                    string[] ors =  both[1].Split(",");
                    Ghost.transform.position = (new Vector3(float.Parse(posi[0]),float.Parse(posi[1]),float.Parse(posi[2])));
                    Ghost.transform.rotation = (new Quaternion(float.Parse(ors[0]),float.Parse(ors[1]),float.Parse(ors[2]),float.Parse(ors[3])));
                    ind++;
                }

            }


    }
}
