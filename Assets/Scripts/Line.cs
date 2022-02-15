using UnityEngine;

public class Line : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;
    public GameObject ball;
    public GameObject player;
    public Vector2 minPower;
    public Vector2 maxPower;

    public Direction dir;

    Camera cam;

    Vector2 force;
    Vector3 startMousePos;
    Vector3 endMousePos;

    public static Line Instance;

    void Awake()
    {
        cam = Camera.main;
        Instance = this;
    }
    void Start()
    {
        dir = GetComponent<Direction>();
    }

    void Update()
    {
        //Debug.Log("vitesse  =  " + rb.velocity.magnitude); // si > 5 rentre pas dans le trou
        if (Reticle.Instance.IsSelected == true)
            MouseDown();
        if (rb.velocity.magnitude > 0.01f)
        {
            player.SetActive(false);
            CircleCollider.Instance.circle.SetActive(false);
        }
        else
        {
            player.SetActive(true);
            CircleCollider.Instance.circle.SetActive(true);
        }
    }

    public void MouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            startMousePos = ball.transform.position;
            startMousePos.z = 15;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            dir.RenderLine(startMousePos, currentPoint);
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
            dir.EndLine();
        }
    }
}
