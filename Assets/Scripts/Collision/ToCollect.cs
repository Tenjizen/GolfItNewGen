using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCollect: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Debug.Log("triggers player!");
            Destroy(this.gameObject);
        }
        if (col.transform.tag == "Ball")
        {
            Debug.Log("triggers ball!");
            Destroy(this.gameObject);
        }
    }

}
