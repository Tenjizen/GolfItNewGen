using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 mousePos;
    private Vector2 startMousePos;

    private float distance;


    public static Line Instance;
    // Start is called before the first frame update

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, new Vector3(startMousePos.x, startMousePos.y, 0f));
            lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0f));
            distance = (mousePos - startMousePos).magnitude;
            Balle.Instance.playerBall.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector2.Lerp(mousePos,startMousePos,0f) * distance));
        }
    }
}
