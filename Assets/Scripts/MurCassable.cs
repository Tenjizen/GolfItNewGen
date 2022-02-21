using UnityEngine;
using System.Collections;

public class MurCassable : MonoBehaviour
{
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
            Debug.Log("DESTRUCTIONNNN!");
            gameObject.SetActive(false);
            collider2D.isTrigger = true;
        }
    }
    private IEnumerator WaitAndPrint()
    {
            yield return new WaitForSeconds(3);
            collider2D.isTrigger = true;
            Debug.Log("trigger true");
        
    }
}
