using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask BallMask;


    private Mesh mesh;
    private float fov;
    private float viewDist;
    private Vector3 origin;
    private float startingAngle;

    private bool collision = false;


    public static FieldOfView Instance;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        fov = 90f;
        viewDist = 20f;
    }

    private void Update()
    {

        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = (fov / rayCount);

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;




        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex; //= origin + UtilsClass.GetVectorFromAngle(angle) * viewDist; 
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDist, layerMask);
            if (raycastHit2D.collider == null)
            {
                //no hit
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDist;
                //Debug.Log("no collider");

            }
            else
            {
                //Hit object
                vertex = raycastHit2D.point;
                //Debug.Log("Salut je test " + viewDist);
            }
            RaycastHit2D raycastHitPlayer2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDist, playerMask);
            RaycastHit2D raycastHitBall2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDist, BallMask);

            if (raycastHitBall2D.collider == null)
            {
                //no hit
            }
            else
            {
                if (raycastHitBall2D.collider.tag == "Ball" && !CircleCollider.Instance.restart)
                {
                    Debug.Log("collision ball ");
                    CircleCollider.Instance.restart = true;
                    collision = true;
                    Reticle.Instance.ready = false;
                    StartCoroutine(Reticle.Instance.RestartLoadScene(5));
                }

            }
            if (raycastHitPlayer2D.collider == null)
            {
                //    //hit
            }
            else
            {
                if (!CircleCollider.Instance.restart && raycastHitPlayer2D.collider.tag == "Player")
                {
                    Debug.Log("collision player");
                    CircleCollider.Instance.restart = true;
                    collision = true;
                    Reticle.Instance.ready = false;
                    StartCoroutine(Reticle.Instance.RestartLoadScene(5));
                }
            }


            vertices[vertexIndex] = vertex;


            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        if (CircleCollider.Instance.restart && Line.Instance.rb.velocity.magnitude < 0.00001f && collision)
        {
            collision = false;
            StartCoroutine(Reticle.Instance.RestartLoadScene(5));
        }

    }




    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void SetAimDir(Vector3 aimDir)
    {
        startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDir) - fov / 2f;
    }
    public void SetFoV(float fov)
    {
        this.fov = fov;
    }
    public void SetViewDist(float viewDist)
    {
        this.viewDist = viewDist;
    }

}

