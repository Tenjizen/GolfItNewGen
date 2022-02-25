using UnityEngine;
using System.Collections;

public class MurCassable : MonoBehaviour
{
    public new Collider2D collider2D;
    private void OnTriggerEnter2D(Collider2D col)
    {

        if (!WheelClub.Instance.Driver)
        {
            collider2D.isTrigger = false;
            Debug.Log("NOOOOOOOO DESTRUCTIONNNN!" + col);
            StartCoroutine(WaitAndPrint());
        }
        else
        {
            if (col.transform.tag != "Player")
            {
                if (Line.Instance.rb.velocity.magnitude > 20)
                {
                    AudioManager.Instance.PlaySound("snd_break_wall");
                    Destroy(this.gameObject);
                    Debug.Log("DESTRUCTIONNNN!" + col);
                    collider2D.isTrigger = true;
                }
                else
                {
                    collider2D.isTrigger = false;
                    Debug.Log("NOOOOOOOO DESTRUCTIONNNN!" + col);
                    StartCoroutine(WaitAndPrint());
                }
            }

            else
            {
                collider2D.isTrigger = false;
                Debug.Log("NOOOOOOOO DESTRUCTIONNNN!" + col);
                StartCoroutine(WaitAndPrint());
            }
        }
    }
    private IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(3);
        collider2D.isTrigger = true;
        Debug.Log("trigger true");

    }
}
