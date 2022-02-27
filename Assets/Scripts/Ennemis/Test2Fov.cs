using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2Fov : MonoBehaviour
{

    public float viewRad;
    public float viewAngle;

    public LayerMask obstacleMask;
    public LayerMask playerMask;

    public float Aim;

    public Animator animatorFrontBack;
    public Animator animatorLeftRight;

    public SpriteRenderer SpriteRenderer;
    public SpriteRenderer SpriteRendererLeftRight;

    private bool started = false;
    private bool flip = false;
    public bool fliped = false;

    Collider2D[] playerInRadius;
    public List<Transform> visiblePlayer = new List<Transform>();

    public static Test2Fov Instance;

    void Awake()
    {
        Instance = this;

        started = true;
        flip = true;
        if (Aim == 0|| Aim == 180)
            SpriteRenderer.enabled = false;
        else
            SpriteRendererLeftRight.enabled = false;
        if (fliped)
        {
            fliped = false;
            animatorLeftRight.SetBool("Left", true);
            animatorFrontBack.SetBool("Front", false);
        }
        else
        {
            fliped = true;
            animatorLeftRight.SetBool("Left", false);
            animatorFrontBack.SetBool("Front", true);
        }
    }

    void Update()
    {
        if (flip)
        {
            flip = false;
            StartCoroutine(FlipFOV(5));

        }
        FindVisiblePlayer();

        if (started)
        {
            transform.Rotate(0, 0, Aim);
            started = false;

            if (Aim != 180 || Aim != -180)
                Aim = 180;
        }

    }

    private void FindVisiblePlayer()
    {
        playerInRadius = Physics2D.OverlapCircleAll(transform.position, viewRad);
        visiblePlayer.Clear();

        for (int i = 0; i < playerInRadius.Length; i++)
        {
            Transform player = playerInRadius[i].transform;
            Vector2 dirPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

            if (Vector2.Angle(dirPlayer, transform.right) < viewAngle / 2)
            {

                float disancePlayer = Vector2.Distance(transform.position, player.position);

                if (!Physics2D.Raycast(transform.position, dirPlayer, disancePlayer, obstacleMask))
                {
                    if (Physics2D.Raycast(transform.position, dirPlayer, disancePlayer, playerMask))
                    {
                        visiblePlayer.Add(player);
                        StartCoroutine(Reticle.Instance.RestartLoadScene(5));
                        Debug.Log("see you");
                        Reticle.Instance.ready = false;

                    }
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


    public IEnumerator FlipFOV(int n)
    {
        yield return new WaitForSeconds(n);
        flip = true;
        if (fliped)
        {
            fliped = false;
            animatorLeftRight.SetBool("Left", true);
            animatorFrontBack.SetBool("Front", false);

        }
        else
        {
            fliped = true;
            animatorLeftRight.SetBool("Left", false);
            animatorFrontBack.SetBool("Front", true);
        }
        Aim = -Aim;
        transform.Rotate(0, 0, Aim);
        Debug.Log("flip");

    }
}
