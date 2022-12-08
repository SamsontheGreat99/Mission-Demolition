using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLineRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;
    LineRenderer followLine;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = this.GetComponent<LineRenderer>();
        followLine = GameObject.FindGameObjectWithTag("Line").GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
