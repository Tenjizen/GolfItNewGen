using UnityEngine;

public class Direction : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;

    public GameObject ball;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void RenderLine(Vector3 ball.transform.position, Vector3 endMousePos)
    {
        lr.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = ball.transform.position;
        points[1] = endMousePos;

        lr.SetPositions(points);
    }

    public void EndLine()
    {
        lr.positionCount = 0;
    }
}
