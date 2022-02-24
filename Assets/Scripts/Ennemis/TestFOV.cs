using System.Collections;
using UnityEngine;
using UnityEditor;

public class TestFOV : MonoBehaviour
{
    public float radius = 5f;
    [Range(1, 360)] public float angle = 45f;

    public LayerMask target;
    public LayerMask obstruction;

    public GameObject playerRef;

    public bool CanSeeBouffon { get; private set; }



    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(FOVCheck());
        playerRef = GameObject.FindGameObjectWithTag("Player");



    }
    void Update()
    {
    }

    private IEnumerator FOVCheck()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FOV();
        }



    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, target);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, dirToTarget) < angle / 2)
            {
                float distToTarget = Vector2.Distance(transform.position, target.position);


                if (!Physics2D.Raycast(transform.position, dirToTarget, distToTarget, obstruction))
                    CanSeeBouffon = true;
                else
                    CanSeeBouffon = false;

            }
            else
                CanSeeBouffon = false;

        }
        else if (CanSeeBouffon)
            CanSeeBouffon = false;


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle01 = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle02 = DirectionFromAngle(-transform.eulerAngles.z, angle / 2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + angle01 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle02 * radius);
        if (CanSeeBouffon)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, playerRef.transform.position);
        }
    }
    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

    }


}
