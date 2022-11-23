using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;

public class Animation_Code : MonoBehaviour
{

    public GameObject[] Body;
    List<string> rows;

    int currentRow = 0;

    // Start is called before the first frame update
    void Start()
    {
        rows = System.IO.File.ReadLines("Assets/CoordinateFile3.txt").ToList();
    }

    // Update is called once per frame
    void Update()   
    {
        string[] points = rows[currentRow].Split(",");
        //print(points[0]);

        for (int i = 0; i<=32; i++)
        {
            float x = float.Parse(points[0 + (i * 3)]) / 100.0f;
            float y = float.Parse(points[1 + (i * 3)]) / 100.0f;
            float z = float.Parse(points[2 + (i * 3)]) / 300.0f; //Z axis value can be change every diffrent video. So if motion isn't look good you can change the divisive value.
            Body[i].transform.localPosition = new Vector3(x, y, z);
        }

        
        currentRow++;

        if (currentRow == rows.Count)
        {
            currentRow = 0;
        }
        Thread.Sleep(35);
    }
}
