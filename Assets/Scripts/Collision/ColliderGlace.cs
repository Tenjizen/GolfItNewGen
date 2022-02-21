using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderGlace : MonoBehaviour
{


    public Rigidbody2D rb;


    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Ball")
        {
            rb.drag = 0;
            Debug.Log("triggers!");
        }

    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Ball")
        {
            rb.drag = 1;
            Debug.Log("Exit triggers!");
        }

    }

}
