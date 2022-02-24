using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCollect: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player"|| col.transform.tag == "Ball")
        {
            Debug.Log(col.transform.tag);
            Destroy(this.gameObject);
            WheelClubManagement.Instance.toCollect++;
        }
        //if (col.transform.tag == "Ball")
        //{
        //    Debug.Log("triggers ball!");
        //    Destroy(this.gameObject);
        //}
    }

}
