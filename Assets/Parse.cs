using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Parse : MonoBehaviour
{
    public GameObject check;
    public GameObject currcheck;
    List<GameObject> checkpoints;
    
    
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> coords = ParseFile();
        //transform.localScale=transform.localScale*0.02564103f;
        checkpoints = placeCheckpoints(coords);
        currcheck = checkpoints[0];
        
          
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    List<Vector3> ParseFile()
    {
        //float ScaleFactor = 0.02564103f;
        float ScaleFactor = 1f;
        List<Vector3> positions = new List<Vector3>();
        string content = System.IO.File.ReadAllText("Assets/Sample-track.txt");
        string[] lines = content.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            string[] coords = lines[i].Split(' ');
            Debug.Log(coords[0]);
            Debug.Log(float.Parse(coords[0]));

            Vector3 pos = new Vector3(float.Parse(coords[0]), float.Parse(coords[1]), float.Parse(coords[2]));
            positions.Add(pos * ScaleFactor);

        }
        Debug.Log(positions[0]);
        return positions;
    }

    List<GameObject> placeCheckpoints(List<Vector3> coords)
    {
        List<GameObject> checks = new List<GameObject>();
        GameObject.Find("OVRCameraRig").transform.position = coords[0];
           for(int i = 0; i < coords.Count; i++)
        {
            GameObject prefab = Instantiate(check,coords[i], new Quaternion(0, 0, 0, 1));
            prefab.transform.Rotate(-90, 0, 0);
            checks.Add(prefab);

        }
        return checks;
    }
}
