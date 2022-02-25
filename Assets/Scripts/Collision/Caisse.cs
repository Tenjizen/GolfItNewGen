using UnityEngine;
using System.Collections;

public class Caisse : MonoBehaviour
{
    public Animator animator;
    public new Collider2D collider2D;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Ball" && Line.Instance.rb.velocity.magnitude < 20)
        {
            collider2D.isTrigger = false;
            Debug.Log("NOOOOOOOO DESTRUCTIONNNN!");
            StartCoroutine(WaitAndPrint());
        }
        else
        {
        //AudioManager.Instance.PlaySound("snd_break_box");
            Debug.Log("DESTRUCTIONNNN!");
            animator.SetBool("explosionCaisse", true);
            StartCoroutine(Destruction());
        }
    }
    private IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(3);
        collider2D.isTrigger = true;
        Debug.Log("trigger true");

    }
    private IEnumerator Destruction()
    {
        yield return new WaitForSeconds(0.7f);
            Destroy(this.gameObject);

            collider2D.isTrigger = true;
        
    }
}