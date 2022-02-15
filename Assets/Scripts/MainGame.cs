using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour
{
    //public GameObject playerBall;

    [SerializeField] private Vector3 aimDirection;
    [SerializeField] private Transform prefabFieldOfView;
    [SerializeField] private float fov = 90f;
    [SerializeField] private float viewDist = 20f;
    
    
    
    private FieldOfView fieldOfView;
    private bool flipFOV = true;


    public static MainGame Instance;
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        fieldOfView = Instantiate(prefabFieldOfView, null).GetComponent<FieldOfView>();
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
    }

    int oldDir = -1;
    IEnumerator RandomAimDir()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
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
        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}

