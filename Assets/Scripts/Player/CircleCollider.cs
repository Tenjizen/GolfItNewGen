using System.Collections;
using UnityEngine;

public class CircleCollider : MonoBehaviour
{
    [SerializeField] private float MoveForce = 20f;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private float radius = 10f;

    public GameObject circle;
    public int shotMax;
    public int countShot;

    public bool restart = false;

    private float horizontal, vertical;
    private bool isWalking;

    public Animator animator;

    private Vector2 m_direction = Vector2.zero;
    private Vector2 lastMoveDirection;

    public static CircleCollider Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        restart = false;
        isWalking = false;

    }
    private void Update()
    {
        circle.transform.position = Line.Instance.ball.GetComponent<Transform>().position;
        float dist = Vector3.Distance(player.transform.position, circle.transform.position);
        if (dist > radius)
        {
            Vector3 fromOrigintoObject = player.transform.position - circle.transform.position;
            fromOrigintoObject *= radius / dist;
            player.transform.position = circle.transform.position + fromOrigintoObject;
            transform.position = player.transform.position;
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if ((horizontal == 0 && vertical == 0) && m_direction.x != 0 || m_direction.y != 0)
        {
            lastMoveDirection = m_direction;
        }
        m_direction = new Vector2(horizontal, vertical);

        Animate();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        player.AddForce(m_direction * MoveForce);
    }
    private void Animate()
    {
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Magnitude", m_direction.magnitude);
        animator.SetFloat("LastHorizontal", lastMoveDirection.x);
        animator.SetFloat("LastVertical", lastMoveDirection.y);

    }


   
    public IEnumerator ReadyTrue(int n)
    {
        yield return new WaitForSeconds(n);
        Reticle.Instance.ready = true;
    }
}
