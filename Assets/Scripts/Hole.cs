using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.15f;
    [SerializeField] private Vector2 velocity = Vector2.zero;

    
    public float maxSpeedForGoal = 5f;
    public bool inHole = false;

    public static Hole Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

    }

    private void Update()
    {
        if (inHole)
        {
            Line.Instance.ball.transform.position = Vector2.MoveTowards(Line.Instance.ball.transform.position, target.transform.position, smoothSpeed * Time.deltaTime);
            Reticle.Instance.ready = false;

        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Ball" && Line.Instance.rb.velocity.magnitude < maxSpeedForGoal)
        {
            inHole = true;
            Line.Instance.rb.velocity = velocity;
        }
    }
}
