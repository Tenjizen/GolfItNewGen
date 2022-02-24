using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Fov : MonoBehaviour
{

    public float viewRad;
    public float viewAngle;

    public  LayerMask obstacleMask;
    public  LayerMask playerMask;

    public float Aim;

    private bool started = false;

    Collider2D[] playerInRadius;
    public List<Transform> visiblePlayer = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        started = true;
    }

    // Update is called once per frame
    void Update()
    {
        FindVisiblePlayer();

        //if (visiblePlayer[] == none)
        //    Debug.Log("see you");
        if (started) {
            transform.Rotate(0, 0, Aim);
            started = false;
        } }

    private void FindVisiblePlayer()
    {
        playerInRadius = Physics2D.OverlapCircleAll(transform.position, viewRad);
        visiblePlayer.Clear();

        for (int i = 0; i < playerInRadius.Length; i++)
        {
            Transform player = playerInRadius[i].transform;
            Vector2 dirPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

            if (Vector2.Angle(dirPlayer, transform.right)< viewAngle/2)
            {

                float disancePlayer = Vector2.Distance(transform.position, player.position);

                if(!Physics2D.Raycast(transform.position, dirPlayer, disancePlayer, obstacleMask))
                {
                    visiblePlayer.Add(player);
            Debug.Log("see you");
                }

            }



        }

    }


    public Vector2 DirFromAngle(float angleDeg, bool global)
    {
        if (!global)
        {
            angleDeg += transform.eulerAngles.z;
        }
        return new Vector2(Mathf.Cos(angleDeg * Mathf.Deg2Rad), Mathf.Sin(angleDeg * Mathf.Deg2Rad));
    }

}
