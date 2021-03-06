using System.Collections;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float power = 10f;
    public Vector2 minPower;
    public Vector2 maxPower;
    [SerializeField] private Direction dir;

    public GameObject player;
    public Rigidbody2D rb;
    public GameObject ball;

    private Camera cam;
    private Vector2 force;
    private Vector3 startMousePos;
    private Vector3 endMousePos;



    public Animator animator;
    public Animator animatorBall;
    public Animator animatorBallOrigin;

    public SpriteRenderer SpriteRenderer;
    public SpriteRenderer SpriteRendererBall;

    public GameObject Wheel;
    public GameObject Pause;

    public static Line Instance;


    [SerializeField] private LineRenderer lr;

    private void Awake()
    {
        cam = Camera.main;
        Instance = this;
        
    }
    private void Start()
    {
        //lr = GetComponent<LineRenderer>();
        dir = GetComponent<Direction>();
    }

    private void Update()
    {
        if (Line.Instance.rb.velocity.magnitude < 0.5f && Reticle.Instance.ready)
        {
            MouseUpMouseDown();
        }


        if (rb.velocity.magnitude > 0.4f || Wheel.activeInHierarchy || Pause.activeInHierarchy)
        {
            Reticle.Instance.ready = false;
        }
        else if (rb.velocity.magnitude < 0.4f && !Hole.Instance.inHole && !CircleCollider.Instance.restart && !Wheel.activeInHierarchy && !Pause.activeInHierarchy)
        {
            Reticle.Instance.ready = true;
            animatorBall.SetBool("IsDriver", false);
            animatorBallOrigin.SetBool("Move", false);
            SpriteRenderer.enabled = true;
            SpriteRendererBall.enabled = false;
        }
        if (!Reticle.Instance.ready)
        {
            NotReady();
        }
        else
        {
            player.SetActive(true);
            CircleCollider.Instance.circle.SetActive(true);
        }
    }

    public void NotReady()
    {
        player.SetActive(false);
        CircleCollider.Instance.circle.SetActive(false);
    }



    public void MouseUpMouseDown()
    {
        if (Reticle.Instance.ready == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("gdgjdfklghkljdg");
                animator.SetBool("StartLancer", true);
                startMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                startMousePos.z = 15;
                Debug.Log(startMousePos);
            }
            if (Input.GetMouseButton(0))
            {


                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15;
                dir.RenderLine(startMousePos, currentPoint);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("ghjfkhgkjghjklhsgldfh BIS");
                animator.SetBool("EndLancer", true);

                StartCoroutine(AnimLancer(0.2f));
                endMousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                endMousePos.z = 15;
                Vector2 dist = (startMousePos - endMousePos)/*.normalized*/;
                Debug.Log(dist+" dist");
                force = new Vector2(
                    Mathf.Clamp(dist.x, minPower.x, maxPower.x)/4,
                    Mathf.Clamp(dist.y, minPower.y, maxPower.y)/4
                    );
                Debug.Log(force+" force");
            }
        }
    }
    public IEnumerator AnimLancer(float n)
    {
        yield return new WaitForSeconds(n);
        Debug.Log("gklfdqsghjsvjnkjdgnfhvksdfgj THIRD");
        animator.SetBool("EndLancer", false);

        rb.AddForce(force * power/4, ForceMode2D.Impulse);
        dir.EndLine();
        Debug.Log(endMousePos);
        CircleCollider.Instance.countShot++;

        if (WheelClub.Instance.Driver)
        {
            animatorBall.SetBool("IsDriver", true);
        
            SpriteRenderer.enabled = true;
            SpriteRendererBall.enabled = false;
        }
        
        
        else if (!WheelClub.Instance.Driver)
        {
            animatorBallOrigin.SetBool("Move", true);
            SpriteRenderer.enabled = false;
            SpriteRendererBall.enabled = true;
        }

        if (power == WheelClub.Instance.powerHybride)
        {
            AudioManager.Instance.PlaySound("snd_hit_hybride");

        }
        else if (power == WheelClub.Instance.powerPutter)
        {
            AudioManager.Instance.PlaySound("snd_hit_putter");
        }
        else if (power == WheelClub.Instance.powerDriver)
        {
            AudioManager.Instance.PlaySound("snd_hit_driver");
        }
        else if (power == WheelClub.Instance.powerWedge)
        {
            AudioManager.Instance.PlaySound("snd_hit_wedge");
        }
        else if (power == WheelClub.Instance.powerSandwitch)
        {
            AudioManager.Instance.PlaySound("snd_hit_sandwich1");
            //AudioManager.Instance.PlaySound("snd_hit_sandwich2");
        }
    }

}
