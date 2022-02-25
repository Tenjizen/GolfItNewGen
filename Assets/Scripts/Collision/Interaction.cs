using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ButtonImage;
    [SerializeField] private Sprite spriteButton;
    [SerializeField] private Sprite spriteButtonUsed;
 
    [SerializeField] private BoxCollider2D Porte;

    public Animator animator;

    private bool ButtonTrigger = false;
    private bool ButtonUsed = false;

    public static Interaction Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ButtonImage.sprite = spriteButton;
    }

    private void Update()
    {

        if (ButtonTrigger && !ButtonUsed && Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("IsOpen", true);
            Debug.Log("Button pressed");
            ButtonUsed = true;
            ButtonImage.sprite = spriteButtonUsed;
        }
        else if (ButtonTrigger && ButtonUsed && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Button already used");
        }


        if (ButtonUsed)
        {
            Porte.enabled = false;

        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            ButtonTrigger = true;
            Debug.Log("triggers!");
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Debug.Log("Exit triggers!");
            ButtonTrigger = false;
        }
    }

}
