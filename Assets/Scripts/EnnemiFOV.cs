using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiFOV : MonoBehaviour
{
    [SerializeField] private SpriteRenderer EnnemiImage;
    [SerializeField] private Sprite spriteEnnemi;
    [SerializeField] private Sprite spriteEnnemiDied;

    [SerializeField] private Vector3 aimDirection;
    public float viewDist = 20f;
    public Transform prefabFieldOfView;
    public Transform ParentFoV;
    public float fov = 90f;

    public Transform player;
    //public GameObject ball;

    private FieldOfView fieldOfView;
    private bool flipFOV = true;

    private bool IsDie = false;

    public static EnnemiFOV Instance;



    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fieldOfView = Instantiate(prefabFieldOfView, ParentFoV).GetComponent<FieldOfView>();
        EnnemiImage.sprite = spriteEnnemi;
    }
    private void Update()
    {

        fieldOfView.SetOrigin(transform.position);
        fieldOfView.SetAimDir(aimDirection);
        fieldOfView.SetFoV(fov);
        fieldOfView.SetViewDist(viewDist);

        //if (flipFOV)
        //{
        //    flipFOV = false;
        //    StartCoroutine(RandomAimDir());
        //}
        FindTargetPlayer();



    }

    //public static float AngleFromToPoint(Vector3 fromPoint,
    //                                 Vector3 toPoint,
    //                                 Vector3 zeroDirection)
    //{
    //    Vector3 targetDirection = toPoint - fromPoint;
    //    float sign = Mathf.Sign(zeroDirection.x * targetDirection.y - zeroDirection.y * targetDirection.x);
    //    float angle = Vector3.Angle(zeroDirection, targetDirection) * sign;
    //    return angle < 0 ? angle + 360 : angle;
    //}
    //public double getAngle(Vector2 me, Vector2 target)
    //{
    //    return Math.Atan2(target.y - me.y, target.x - me.x) * (180 / Math.PI);
    //}



    private void FindTargetPlayer()
    {
        //float angle = Mathf.Abs(Mathf.Round(Mathf.Atan2(aimDirection.z - player.position.z, aimDirection.x - player.position.x) * Mathf.Rad2Deg));
        //Debug.Log("angle" + angle);
        //Debug.Log("angle dirToPlayer " + Math.Atan2(player.transform.position.y - aimDirection.y, player.transform.position.x - aimDirection.x) * (180 / Math.PI));
        if (Vector3.Distance(transform.position, player.transform.position) < viewDist)
        {
        Vector3 dirToPlayer = (player.transform.position - transform.position).normalized;

        //if(Vector3.Angle(aimDirection, dirToPlayer) > fov /2f && Vector3.Angle(aimDirection, dirToPlayer) < fov * 1.5f)
        //{
        //Debug.Log("in FoV");
        RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, player.transform.position, viewDist);
        if (raycastHit2D.collider != null)
        {
            if (raycastHit2D.collider.transform.tag == "Player")
            {

                Debug.Log(raycastHit2D.collider.name);
                Debug.Log("in FoV");
            }
            else
            {

            }
        }
        }
        //}
    }


    IEnumerator RandomAimDir()
    {
        yield return new WaitForSeconds(5);


        //flip
        aimDirection.x *= -1;
        aimDirection.y *= -1;
        flipFOV = true;

        /*        int dir = Random.Range(0, 3);
                while (oldDir == dir)
                {
                    dir = Random.Range(0, 3);
                }
                oldDir = dir;

                if (dir == 0)
                {
                    aimDirection.y = 1; //droite
                    aimDirection.x = 0;
                }
                else if (dir == 1)
                {
                    aimDirection.y = -1; //gauche
                    aimDirection.x = 0;
                }
                else if (dir == 2)
                {
                    aimDirection.x = -1; //haut
                    aimDirection.y = 0;
                }
                else if (dir == 3)
                {
                    aimDirection.x = 1; //bas
                    aimDirection.y = 0;
                }*/
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!IsDie && col.transform.tag == "Ball" && Line.Instance.rb.velocity.magnitude > Hole.Instance.maxSpeedForGoal)
        {
            Debug.Log("triggers! ");
            //Destroy(this.gameObject);
            Destroy(fieldOfView.gameObject);
            EnnemiImage.sprite = spriteEnnemiDied;
            IsDie = true;
        }
    }
}
