using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private float power = 10f;
    [SerializeField] private Vector2 minPower;
    [SerializeField] private Vector2 maxPower;
    [SerializeField] private Direction dir;

    public GameObject player;
    public Rigidbody2D rb;
    public GameObject ball;

    private Camera cam;
    private Vector2 force;
    private Vector3 startMousePos;
    private Vector3 endMousePos;

    public static Line Instance;

    private void Awake()
    {
        cam = Camera.main;
        Instance = this;
    }
    private void Start()
    {
        dir = GetComponent<Direction>();
    }

    private void Update()
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
            if (CircleCollider.Instance.countShot >= CircleCollider.Instance.shotMax)
            {
                player.SetActive(false);
                CircleCollider.Instance.circle.SetActive(false);
            }
            else
            {
                if (!Hole.Instance.inHole)
                {
                    player.SetActive(true);
                    CircleCollider.Instance.circle.SetActive(true);
                }
            }
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
