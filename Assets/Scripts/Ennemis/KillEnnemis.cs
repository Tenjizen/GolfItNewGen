using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnnemis : MonoBehaviour
{


    public SpriteRenderer SpriteRenderer;
    [SerializeField] private Sprite spriteEnnemisDie;


    private bool collisionWithEnnemi = false;

    private void Update()
    {
        if (collisionWithEnnemi && Input.GetKeyDown(KeyCode.E))
        {
            SpriteRenderer.sprite = spriteEnnemisDie;
            transform.Find("FOV").gameObject.SetActive(false);
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

}
