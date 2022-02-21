using System.Collections;
using UnityEngine;

public class CircleCollider : MonoBehaviour
{
    [SerializeField] private float MoveForce = 20f;
    [SerializeField] private Rigidbody2D player; // get the player transform, or w/e object you want to limit in a circle
    [SerializeField] private float radius = 10f; // this is the range you want the player to move without restriction

    public GameObject circle;  // this is a location that is set to the middle of my world, it will be the center of your circle.
    public int shotMax;
    public int countShot;

    public bool restart = false;

    private Vector2 m_direction = Vector2.zero;

    public static CircleCollider Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //Reticle.Instance.ready = false;
        restart = false;
        //StartCoroutine(ReadyTrue(1));

    }

    private void Update()
    {
        circle.transform.position = Line.Instance.ball.GetComponent<Transform>().position;
        float dist = Vector3.Distance(player.transform.position, circle.transform.position); // the distance from player current position to the circleCenter

        if (dist > radius)
        {
            Vector3 fromOrigintoObject = player.transform.position - circle.transform.position;
            fromOrigintoObject *= radius / dist;
            player.transform.position = circle.transform.position + fromOrigintoObject;
            transform.position = player.transform.position;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_direction = new Vector2(horizontal, vertical);
    }
    private void FixedUpdate()
    {
        if (m_direction.magnitude > 0.1f)
        {
            player.AddForce(m_direction * MoveForce);
        }
    }
    public IEnumerator ReadyTrue(int n)
    {
        yield return new WaitForSeconds(n);
        Reticle.Instance.ready = true;

    }
}
