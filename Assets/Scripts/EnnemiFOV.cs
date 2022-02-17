using UnityEngine;
using System.Collections;

public class EnnemiFOV : MonoBehaviour
{
    //public GameObject playerBall;

    [SerializeField] private Vector3 aimDirection;
    [SerializeField] private Transform prefabFieldOfView;
    [SerializeField] private Transform ParentFoV;
    [SerializeField] private float viewDist = 20f;
    public float fov = 90f;

    private float oldFoV;
    private FieldOfView fieldOfView; 
    private bool flipFOV = true;

    public static EnnemiFOV Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        //ParentFoV.transform.position = this.transform.position; 
        fieldOfView = Instantiate(prefabFieldOfView, ParentFoV).GetComponent<FieldOfView>();
        oldFoV = fov;
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

        //if (KillEnnemi.Instance.Killed)
        //    fov = 0f;
        //else
        //    fov = oldFoV;
    }

    //int oldDir = -1;
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
}

