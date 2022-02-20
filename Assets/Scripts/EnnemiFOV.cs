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

    private FieldOfView fieldOfView;
    private bool flipFOV = true;

    private bool IsDie = false;
    private bool ContactWithEnnemy = false;

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

        if (flipFOV)
        {
            flipFOV = false;
            StartCoroutine(RandomAimDir());
        }


        if (ContactWithEnnemy && Input.GetKeyDown(KeyCode.E)
    )
        {
            Debug.Log("T'es mort avec le player");
            Destroy(fieldOfView.gameObject);
            EnnemiImage.sprite = spriteEnnemiDied;
            IsDie = true;
            ContactWithEnnemy = false;
        }

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
            Debug.Log("Creve avec la balle ");
            Destroy(fieldOfView.gameObject);
            EnnemiImage.sprite = spriteEnnemiDied;
            IsDie = true;
        }

        if (!IsDie && col.transform.tag == "Player")
        {
            Debug.Log("Collision chef");
            ContactWithEnnemy = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
       
        if (!IsDie && col.transform.tag == "Player")
        {
            Debug.Log("J'me tire");
            ContactWithEnnemy = false;
        }
    }
}
