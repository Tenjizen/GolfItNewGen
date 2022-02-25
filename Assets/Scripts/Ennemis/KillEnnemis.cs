using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnnemis : MonoBehaviour
{


    public SpriteRenderer SpriteRenderer;
    [SerializeField] private Sprite spriteEnnemisDie;
    public Animator animator;

    private bool collisionWithEnnemi = false;

    private void Update()
    {
        if (collisionWithEnnemi && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("IsAttacking", true);
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
            SpriteRenderer.sprite = spriteEnnemisDie;
            transform.Find("FOV").gameObject.SetActive(false);
            Debug.Log("triggers BALL!");
        }

    }

    public IEnumerator AnimAttacking(float n)
    {
        yield return new WaitForSeconds(n);
        animator.SetBool("IsAttacking", false);
    }
}
