using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GhostWriteScript : MonoBehaviour
{
    int ticks = 90;
    float t;
    List<string> pos = new List<string>();
    List<string> currentBest = new List<string>();
    public GameObject aircraft;
    public GameObject Ghost;
    string curFile;
    bool done;
    bool some;
    public bool exist;
    int ind =0;
    public TimerScript timer;
    public TMPro.TextMeshPro Timer;
    public GhostMoveScript moveScript;
    
    // Start is called before the first frame update
    void Start()
    {
        done=false;
        some=false;
        t=0;
        curFile="C:/Users/alobo/Downloads/Best.txt";
        if(File.Exists(curFile)){
            exist=true;
           
        }
        else{
            Ghost.SetActive(false);
            exist=false;
        }
        Debug.Log(currentBest.Count);
        
    }

    // Update is called once per frame
    void Update()
    {
        float dur = 1f/ticks;
        t+=Time.deltaTime;
        
        if(!timer.start){
            some=true;
            
            while(t>=dur){
                t-=dur;
                string posor = aircraft.transform.position.x.ToString()+","+aircraft.transform.position.y.ToString()+","+aircraft.transform.position.z.ToString();
                posor+=";";
                posor+= aircraft.transform.rotation.x.ToString()+","+aircraft.transform.rotation.y.ToString()+","+aircraft.transform.rotation.z.ToString()+","+aircraft.transform.rotation.w.ToString();
                
                pos.Add(posor);

            }
        }
        else if(timer.start&&some&&!done){
            done=true;
            pos.Add(Timer.text);
            bool faster=false;
            if(exist){
                string lasttime=moveScript.currentBest[moveScript.currentBest.Count-1];
                int lastminutes= int.Parse(lasttime[0].ToString()+lasttime[1].ToString());
                int lastseconds =int.Parse(lasttime[3].ToString()+lasttime[4].ToString());
                string currtime = Timer.text;
                int currminutes=int.Parse(currtime[0].ToString()+currtime[1].ToString());
                int currseconds =int.Parse(currtime[3].ToString()+currtime[4].ToString());
                if(currminutes<lastminutes){
                    faster=true;
                }
                else if(currminutes==lastminutes&&currseconds<lastseconds){
                    faster=true;
                }
            }
            else{
                faster=true;
            }
            if(faster){
                using (StreamWriter write = new StreamWriter(curFile))
                {
                for(int i =0;i<pos.Count;i++){
                    write.WriteLine(pos[i]);
                }
                }
                Debug.Log(Timer.text);
            }
        }

    }
}
