using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    //public GameObject Ball;
    public float maxSpeedForGoal = 5f;

    public static Hole Instance;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
            Debug.Log(Reticle.Instance.ready);
    }

    private void Update()
    {
        if(Reticle.Instance.ready == false)
            Line.Instance.ball.transform.position = Vector2.MoveTowards(Line.Instance.ball.transform.position, target.transform.position, smoothSpeed*Time.deltaTime);

    }
    /* void OnTriggerEnter2D(Collider2D obj)
     {
         if (obj.transform.tag == "Ball" && Line.Instance.rb.velocity.magnitude < maxSpeedForGoal)
         {

         }
     }*/



    public Transform target;

    public float smoothSpeed = 0.15f;
    public Vector2 velocity = Vector2.zero;

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.transform.tag == "Ball" && Line.Instance.rb.velocity.magnitude < maxSpeedForGoal)
        {
             //StartCoroutine(Goal(col.gameObject));
            //Debug.Log("triggers!");
            Reticle.Instance.ready = false;
            Line.Instance.rb.velocity = velocity;
        }

        
    }
    

}
