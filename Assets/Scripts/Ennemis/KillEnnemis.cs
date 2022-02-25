using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnnemis : MonoBehaviour
{


    public SpriteRenderer SpriteRenderer;
    [SerializeField] private Sprite spriteEnnemisDie;

    public Test2Fov fov;

    public Animator animator;

    private bool collisionWithEnnemi = false;

    private void Update()
    {
        if (collisionWithEnnemi && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("IsAttacking", true);
            AudioManager.Instance.PlaySound("snd_hit_man");
            AudioManager.Instance.PlaySound("snd_ennemy_death1");
            SpriteRenderer.sprite = spriteEnnemisDie;
            transform.Find("FOV").gameObject.SetActive(false);
            StartCoroutine(AnimAttacking(1.5f));
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            collisionWithEnnemi = true;
            Debug.Log("triggers!");
        }
        else if (col.transform.tag == "Ball")
        {
            fov.animatorLeftRight.enabled = false;
            fov.animatorFrontBack.enabled = false;
            fov.SpriteRenderer.enabled = true;
            fov.SpriteRendererLeftRight.enabled = false;
            SpriteRenderer.sprite = spriteEnnemisDie;
            transform.Find("FOV").gameObject.SetActive(false);
            Debug.Log("triggers BALL!");
            //Test2Fov.Instance.animatorLeftRight.SetBool("IsAlive", false);

        }

    }

    public IEnumerator AnimAttacking(float n)
    {
        yield return new WaitForSeconds(n);
        animator.SetBool("IsAttacking", false);
    }
}
