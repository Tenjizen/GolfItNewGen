using UnityEngine;

public class Direction : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;

    public GameObject ball;
    private Vector3 ballPos;

    private void Awake()
    {
        ballPos = transform.position;
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 startMousePos, Vector3 endMousePos)
    {
        //startMousePos
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
