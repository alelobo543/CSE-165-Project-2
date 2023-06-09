using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class Parse : MonoBehaviour
{
    public GameObject check;
    public GameObject currcheck;
    public List<GameObject> checkpoints;
    public int currindex;
    
    
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> coords = ParseFile();
        //transform.localScale=transform.localScale*0.02564103f;
        checkpoints = placeCheckpoints(coords);
        currcheck = checkpoints[0];
        currcheck.transform.GetComponent<Collider>().enabled = true;
        GameObject.Find("Aircraft").transform.LookAt(checkpoints[1].transform);
        currindex = 0;
        
        GameObject.Find("Aircraft").transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GameObject.Find("Aircraft").transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        Quaternion r = GameObject.Find("Aircraft").transform.rotation;
        GameObject.Find("Aircraft").transform.Rotate(-r.eulerAngles.x, 0, -r.eulerAngles.z);




    }

    // Update is called once per frame
    void Update()
    {
    }
    List<Vector3> ParseFile()
    {
        float ScaleFactor = 1.0f / 39.37f;
        TextAsset file = Resources.Load("checkpoint_grading") as TextAsset;
        string content = file.text;
        List<Vector3> positions = new List<Vector3>();
        string[] lines = content.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            string[] coords = lines[i].Split(' ');


            Vector3 pos = new Vector3(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2]));
            positions.Add(pos * ScaleFactor);

        }
        
        return positions;
    }

    List<GameObject> placeCheckpoints(List<Vector3> coords)
    {
        List<GameObject> checks = new List<GameObject>();
        GameObject.Find("Aircraft").transform.position = coords[0];
        GameObject.Find("Ghost").transform.position = coords[0];
           for(int i = 0; i < coords.Count; i++)
        {
            GameObject prefab = Instantiate(check,coords[i], new Quaternion(0, 0, 0, 1));
            prefab.transform.Rotate(-90, 0, 0);
            prefab.transform.GetComponent<Collider>().enabled=false;
            prefab.transform.GetChild(0).GetComponent<TMPro.TextMeshPro>().text = "#" + i.ToString();
            prefab.transform.GetChild(0).transform.LookAt(Camera.main.transform);
            prefab.transform.GetChild(0).transform.Rotate(0, 180, 0);
            checks.Add(prefab);

        }
        return checks;
    }
    public void next()
    {
        currindex += 1;
        currcheck.SetActive(false);
        if(currindex < checkpoints.Count){
            currcheck = checkpoints[currindex];
            currcheck.transform.GetComponent<Collider>().enabled=true;
        }
    }
}
