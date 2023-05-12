using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWayfinder : MonoBehaviour
{
    public Parse parser;
    public LineRenderer line;
    LineRenderer lineInstance;
    // Start is called before the first frame update
    void Start()
    {
        lineInstance = Instantiate(line);
    }

    // Update is called once per frame
    void Update()
    {
        
        int index = parser.currindex;
        if(index < parser.checkpoints.Count){
            Vector3[] positions = new Vector3[2];
            positions[0] = parser.checkpoints[index].transform.position;
            positions[1] = parser.checkpoints[index -1].transform.position;
            lineInstance.enabled = true;
            lineInstance.SetWidth(1.5f, 1.5f);
            lineInstance.SetPositions(positions);
        }

    }
}
