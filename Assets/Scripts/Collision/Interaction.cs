using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    [SerializeField] private SpriteRenderer ButtonImage;
    [SerializeField] private Sprite spriteButton;
    [SerializeField] private Sprite spriteButtonUsed;
    [SerializeField] private GameObject Porte;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private int moveDoor;

    private bool ButtonTrigger = false;
    private bool ButtonUsed = false;

    public static Interaction Instance;
    private Vector2 newPosition;

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
            Debug.Log("Button pressed");
            ButtonUsed = true;
            ButtonImage.sprite = spriteButtonUsed;
            newPosition = Porte.transform.position;
            newPosition.y = newPosition.y + moveDoor;
        }
        else if (ButtonTrigger && ButtonUsed && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Button already used");
        }


        if (ButtonUsed)
        {
            Porte.transform.position = Vector2.MoveTowards(Porte.transform.position, newPosition, smoothSpeed * Time.deltaTime);
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
