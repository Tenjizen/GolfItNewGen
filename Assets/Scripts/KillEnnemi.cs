using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnnemi : MonoBehaviour
{
    public bool Killed = false;

    public static KillEnnemi Instance;

    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Killed)
            EnnemiFOV.Instance.fov = 0f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Ball" && Line.Instance.rb.velocity.magnitude > Hole.Instance.maxSpeedForGoal)
        {
            Debug.Log("triggers!");
            Killed = true;
        }
    }
}
