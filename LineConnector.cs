using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    LineRenderer lineRenderer;

    public Transform sPoint;
    public Transform ePoint;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth= 0.15f;
        lineRenderer.endWidth = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, sPoint.localPosition);
        lineRenderer.SetPosition(1, ePoint.localPosition);
    }
}
