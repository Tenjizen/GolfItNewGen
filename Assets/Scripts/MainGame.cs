using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour
{
    /*public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    public Line line;

    Camera cam;

    Vector2 force;
    Vector3 startMousePos;
    Vector3 endMousePos;

	public static MainGame Instance;

	void Awake()
	{
		Instance = this;
	}


    void Start()
    {
        cam = Camera.main;
        line = GetComponent<Line>();
    }

    void Update()
    {

        if (Reticle.Instance.IsSelected == true)
            MouseDown();
    }

    public void MouseDown()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            startMousePos.z = 15;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            line.RenderLine(startMousePos, currentPoint);
        }

    }
    public void MouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            endMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            endMousePos.z = 15;

            force = new Vector2(Mathf.Clamp(
                startMousePos.x - endMousePos.x, minPower.x, maxPower.x),
                Mathf.Clamp(startMousePos.y - endMousePos.y, minPower.y, maxPower.y)
                );
            rb.AddForce(force * power, ForceMode2D.Impulse);
            line.EndLine();
        }
    }*/
}

