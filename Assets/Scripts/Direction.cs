using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Direction : MonoBehaviour
{
    public LineRenderer lr;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startMousePos, Vector3 endMousePos)
    {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = startMousePos;
        points[1] = endMousePos;

        lr.SetPositions(points);
    }

    public void EndLine()
    {
        lr.positionCount = 0;
    }

}
